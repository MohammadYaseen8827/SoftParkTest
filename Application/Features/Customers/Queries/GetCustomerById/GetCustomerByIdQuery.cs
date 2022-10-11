using AutoMapper;
using MediatR;
using Platform.Application.Exceptions;
using Platform.Application.Features.Customers.Queries.GetAllCustomers;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;

namespace Platform.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Response<GetAllCustomersViewModel>>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<GetAllCustomersViewModel>>
        {
            private readonly ICustomerRepositoryAsync _customerRepository;

            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(ICustomerRepositoryAsync customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }
            public async Task<Response<GetAllCustomersViewModel>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(query.Id);
                if (customer == null) throw new ApiException($"Customer Not Found.");
                var customerViewModel = _mapper.Map<GetAllCustomersViewModel>(customer);

                return new Response<GetAllCustomersViewModel>(customerViewModel);
            }
        }
    }
}
