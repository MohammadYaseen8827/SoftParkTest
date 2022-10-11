using AutoMapper;
using MediatR;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;
using Platform.Domain.Entities;
using Platform.Domain.Enums;
using Platform.Domain.Events.HouseEvents;

namespace Platform.Application.Features.Houses.Commands.CreateHouse;
public partial class CreateHouseCommand : HouseCommandBase, IRequest<Response<int>>
{
    public OfferType OfferType { get; init; }

}
public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand, Response<int>>
{
    private readonly IHouseRepositoryAsync _houseRepository;
    private readonly IMapper _mapper;
    public CreateHouseCommandHandler(IHouseRepositoryAsync houseRepository, IMapper mapper)
    {
        _houseRepository = houseRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateHouseCommand command, CancellationToken cancellationToken)
    {
        var house = _mapper.Map<House>(command);

        house.AddDomainEvent(new HouseCreatedEvent(house));

        await _houseRepository.AddAsync(house);

        return new Response<int>(house.Id);
    }
}
