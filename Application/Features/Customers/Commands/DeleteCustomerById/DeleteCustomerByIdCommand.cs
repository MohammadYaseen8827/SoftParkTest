using MediatR;
using Platform.Application.Exceptions;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;
using Platform.Domain.Events.CustomerEvents;

namespace Platform.Application.Features.Customers.Commands.DeleteCustomerById
{
    public class DeleteCustomerByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, Response<int>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;
            public DeleteCustomerByIdCommandHandler(ICustomerRepositoryAsync customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<Response<int>> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(command.Id);
                if (customer == null) throw new ApiException($"Customer Not Found.");

                customer.AddDomainEvent(new CustomerDeletedEvent(customer));

                await _customerRepository.DeleteAsync(customer);

                return new Response<int>(customer.Id);
            }
        }
    }
}
