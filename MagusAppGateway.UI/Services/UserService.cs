using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.ViewModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MagusAppGateway.UI.Result;
using Newtonsoft.Json;

namespace MagusAppGateway.UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultModel<string>> AddUser(UserCreateOrEditDto dto)
        {
            var userJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Users/CreateUser", userJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> EditUser(UserCreateOrEditDto dto)
        {
            var userJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Users/UpdateUser", userJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<PagedList<UserDto>>> GetUserPage(UserQueryDto dto)
        {
            var userJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Users/GetUsers", userJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<PagedList<UserDto>>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
        
        public async Task<ResultModel<UserDto>> GetUserById(string id)
        {
            return JsonConvert.DeserializeObject<ResultModel<UserDto>>(
                await _httpClient.GetStringAsync($"/api/Users/GetById?id={id}"));
        }
    }
}
