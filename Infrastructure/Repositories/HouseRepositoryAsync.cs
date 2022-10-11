using Platform.Application.Interfaces.Repositories;
using Platform.Domain.Entities;
using Platform.Infrastructure.Persistence;

namespace Platform.Infrastructure.Repositories
{
    public class HouseRepositoryAsync : GenericRepositoryAsync<House>, IHouseRepositoryAsync
    {
        public HouseRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
