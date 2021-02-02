using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.ViewModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MagusAppGateway.UI.Result;
using Newtonsoft.Json;

namespace MagusAppGateway.UI.Services
{
    public class ClientService:IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultModel<string>> AddClient(ClientEditDto dto)
        {
            var clientJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Client/CreateClient", clientJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> EditClient(ClientEditDto dto)
        {
            var clientJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Client/UpdateClient", clientJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<ClientDto>> GetById(int id)
        {
            return JsonConvert.DeserializeObject<ResultModel<ClientDto>>(
                await _httpClient.GetStringAsync($"/api/Client/GetById?id={id}"));
        }

        public async Task<ResultModel<PagedList<ClientDto>>> GetClientPage(ClientQueryDto dto)
        {
            var clientJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Client/GetPageList", clientJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<PagedList<ClientDto>>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
