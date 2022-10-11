using AutoMapper;
using MediatR;
using Platform.Application.Exceptions;
using Platform.Application.Features.Houses.Queries.GetAllHouses;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;

namespace Platform.Application.Features.Houses.Queries.GetHouseByIdQuery
{
    public class GetHouseByIdQuery : IRequest<Response<GetAllHousesViewModel>>
    {
        public int Id { get; set; }
        public class GetHouseByIdQueryHandler : IRequestHandler<GetHouseByIdQuery, Response<GetAllHousesViewModel>>
        {
            private readonly IHouseRepositoryAsync _houseRepository;
            private readonly IMapper _mapper;

            public GetHouseByIdQueryHandler(IHouseRepositoryAsync houseRepository, IMapper mapper)
            {
                _houseRepository = houseRepository;
                _mapper = mapper;
            }
            public async Task<Response<GetAllHousesViewModel>> Handle(GetHouseByIdQuery query, CancellationToken cancellationToken)
            {
                var house = await _houseRepository.GetByIdAsync(query.Id);
                if (house == null) throw new ApiException($"House Not Found.");
                var houseViewModel = _mapper.Map<GetAllHousesViewModel>(house);

                return new Response<GetAllHousesViewModel>(houseViewModel);
            }
        }
    }
}
