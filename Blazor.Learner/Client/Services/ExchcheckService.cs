using BlazorCookies.Models;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace BlazorCookies.Client.Services
{
    public class ExchcheckService : ICrudDataService<EXCHCHECK>
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri;

        public ExchcheckService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _baseUri = navigationManager.BaseUri;
        }

        public async Task<EXCHCHECK> Get(params object[] keys)
        {
            int orderId;
            int.TryParse(keys[0].ToString(), out orderId);
            return await _httpClient.GetFromJsonAsync<EXCHCHECK>(_baseUri + $"api/ExchCheck/{orderId}");
        }

        public async Task Insert(EXCHCHECK item)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUri + $"api/ExchCheck/", item);
            if (!response.IsSuccessStatusCode)
            {
                throw new GridException("ORDSRV-01", "Error creating the order");
            }
        }

        public async Task Update(EXCHCHECK item)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUri + $"api/ExchCheck/{item.EC_ID}", item);
            if (!response.IsSuccessStatusCode)
            {
                throw new GridException("ORDSRV-02", "Error updating the order");
            }
        }

        public async Task Delete(params object[] keys)
        {
            int orderId;
            int.TryParse(keys[0].ToString(), out orderId);
            var response = await _httpClient.DeleteAsync(_baseUri + $"api/ExchCheck/{orderId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new GridException("ORDSRV-03", "Error deleting the order");
            }
        }
    }
}
