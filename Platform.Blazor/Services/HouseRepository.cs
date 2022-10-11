using Blazored.LocalStorage;
using Platform.Blazor.Interfaces;
using Platform.Blazor.Models;

namespace Platform.Blazor.Services
{
    public class HouseRepository : BaseRepository<House>, IHouseRepository
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;
        public HouseRepository(IHttpClientFactory client,
            ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
    }
}
