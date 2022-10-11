using AutoMapper;
using MediatR;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;

namespace Platform.Application.Features.Houses.Queries.GetAllHouses
{
    public class GetAllHousesQuery : IRequest<PagedResponse<IEnumerable<GetAllHousesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllHousesQueryHandler : IRequestHandler<GetAllHousesQuery, PagedResponse<IEnumerable<GetAllHousesViewModel>>>
    {
        private readonly IHouseRepositoryAsync _houseRepository;
        private readonly IMapper _mapper;
        public GetAllHousesQueryHandler(IHouseRepositoryAsync houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllHousesViewModel>>> Handle(GetAllHousesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllHousesParameter>(request);
            var house = await _houseRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var houseViewModel = _mapper.Map<IEnumerable<GetAllHousesViewModel>>(house);
            return new PagedResponse<IEnumerable<GetAllHousesViewModel>>(houseViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
