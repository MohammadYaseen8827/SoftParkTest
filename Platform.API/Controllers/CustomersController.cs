using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Customers.Commands.CreateCustomer;
using Platform.Application.Features.Customers.Commands.DeleteCustomerById;
using Platform.Application.Features.Customers.Commands.UpdateCustomer;
using Platform.Application.Features.Customers.Queries.GetAllCustomers;
using Platform.Application.Features.Customers.Queries.GetCustomerById;

namespace Platform.API.Controllers;

[Authorize]
public class CustomersController : ApiControllerBase
{
    // GET: api/<controller>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllCustomersParameter filter)
    {

        return Ok(await Mediator.Send(new GetAllCustomersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
    }

    // POST api/<controller>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(CreateCustomerCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Put(int id, UpdateCustomerCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteCustomerByIdCommand { Id = id }));
    }
}
