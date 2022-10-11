using MediatR;
using Platform.Application.Exceptions;
using Platform.Application.Interfaces.Repositories;
using Platform.Application.Wrappers;
using Platform.Domain.Events.HouseEvents;

namespace Platform.Application.Features.Houses.Commands.DeleteHouseById
{
    public class DeleteHouseByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteHouseByIdCommandHandler : IRequestHandler<DeleteHouseByIdCommand, Response<int>>
        {
            private readonly IHouseRepositoryAsync _houseRepository;
            public DeleteHouseByIdCommandHandler(IHouseRepositoryAsync houseRepository)
            {
                _houseRepository = houseRepository;
            }
            public async Task<Response<int>> Handle(DeleteHouseByIdCommand command, CancellationToken cancellationToken)
            {
                var house = await _houseRepository.GetByIdAsync(command.Id);
                if (house == null) throw new ApiException($"House Not Found.");

                house.AddDomainEvent(new HouseDeletedEvent(house));

                await _houseRepository.DeleteAsync(house);

                return new Response<int>(house.Id);
            }
        }
    }
}
