using Blazored.LocalStorage;
using Platform.Blazor.Interfaces;
using Platform.Blazor.Models;

namespace Platform.Blazor.Services
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IHttpClientFactory client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
