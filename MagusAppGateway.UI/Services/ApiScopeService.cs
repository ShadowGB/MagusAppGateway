using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.ViewModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MagusAppGateway.UI.Result;
using Newtonsoft.Json;

namespace MagusAppGateway.UI.Services
{
    public class ApiScopeService : IApiScopeService
    {
        private readonly HttpClient _httpClient;

        public ApiScopeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultModel<string>> AddApiScope(ApiScopeEditDto dto)
        {
            var apiJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/ApiScope/CreateApiScope", apiJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> EditApiScope(ApiScopeEditDto dto)
        {
            var apiJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/ApiScope/UpdateApiScope", apiJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public Task<ResultModel<ApiScopeDto>> GetApiScopeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResultModel<PagedList<ApiScopeDto>>> GetApiScopePage(ApiScopeQueryDto dto)
        {
            var apiJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/ApiScope/GetList", apiJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<PagedList<ApiScopeDto>>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
