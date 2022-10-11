using Platform.Application.Interfaces.Repositories;
using Platform.Domain.Entities;
using Platform.Infrastructure.Persistence;

namespace Platform.Infrastructure.Repositories
{
    public class CustomerRepositoryAsync : GenericRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        public CustomerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
