using AutoMapper;
using MediatR;
using Platform.Application.Exceptions;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;
using Platform.Domain.Entities;
using Platform.Domain.Enums;
using Platform.Domain.Events.HouseEvents;

namespace Platform.Application.Features.Houses.Commands.UpdateHouse
{
    public class UpdateHouseCommand : HouseCommandBase, IRequest<Response<int>>
    {
        public int Id { get; init; }

        public OfferType OfferType { get; init; }

        public class UpdateHouseCommandHandler : IRequestHandler<UpdateHouseCommand, Response<int>>
        {
            private readonly IHouseRepositoryAsync _houseRepository;

            private readonly IMapper _mapper;

            public UpdateHouseCommandHandler(IHouseRepositoryAsync houseRepository, IMapper mapper)
            {
                _houseRepository = houseRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(UpdateHouseCommand command, CancellationToken cancellationToken)
            {
                var house = await _houseRepository.GetByIdAsync(command.Id);

                if (house == null)
                {
                    throw new ApiException($"House Not Found.");
                }
                else
                {
                    _mapper.Map(command, house);

                    house.AddDomainEvent(new HouseUpdatedEvent(house));

                    await _houseRepository.UpdateAsync(house);

                    

                    return new Response<int>(house.Id);
                }
            }
        }
    }
}
