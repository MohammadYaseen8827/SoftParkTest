using AutoMapper;
using MediatR;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;
using Platform.Domain.Entities;
using Platform.Domain.Events.CustomerEvents;

namespace Platform.Application.Features.Customers.Commands.CreateCustomer;
public partial class CreateCustomerCommand : CustomerCommandBase, IRequest<Response<int>>
{
    public string? FirstName { get; init; }

    public string? LastName { get; init; }
}
public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
{
    private readonly ICustomerRepositoryAsync _customerRepository;
    private readonly IMapper _mapper;
    public CreateCustomerCommandHandler(ICustomerRepositoryAsync customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(command);

        customer.AddDomainEvent(new CustomerCreatedEvent(customer));

        await _customerRepository.AddAsync(customer);

        return new Response<int>(customer.Id);
    }
}
