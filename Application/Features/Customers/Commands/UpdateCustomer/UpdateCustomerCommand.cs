using AutoMapper;
using MediatR;
using Platform.Application.Exceptions;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;
using Platform.Domain.Entities;
using Platform.Domain.Events.CustomerEvents;

namespace Platform.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : CustomerCommandBase, IRequest<Response<int>>
    {
        public int Id { get; init; }

        public string? FirstName { get; init; }

        public string? LastName { get; init; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;

            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(ICustomerRepositoryAsync customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(command.Id);

                if (customer == null)
                {
                    throw new ApiException($"Customer Not Found.");
                }
                else
                {
                    _mapper.Map(command, customer);

                    customer.AddDomainEvent(new CustomerUpdatedEvent(customer));

                    await _customerRepository.UpdateAsync(customer);

                    return new Response<int>(customer.Id);
                }
            }
        }
    }
}
