using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Houses.Commands.CreateHouse;
using Platform.Application.Features.Houses.Commands.DeleteHouseById;
using Platform.Application.Features.Houses.Commands.UpdateHouse;
using Platform.Application.Features.Houses.Queries.GetAllHouses;
using Platform.Application.Features.Houses.Queries.GetHouseByIdQuery;

namespace Platform.API.Controllers;

[Authorize]
public class HousesController : ApiControllerBase
{
    // GET: api/<controller>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllHousesParameter filter)
    {

        return Ok(await Mediator.Send(new GetAllHousesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetHouseByIdQuery { Id = id }));
    }

    // POST api/<controller>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(CreateHouseCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Put(int id, UpdateHouseCommand command)
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
        return Ok(await Mediator.Send(new DeleteHouseByIdCommand { Id = id }));
    }
}
