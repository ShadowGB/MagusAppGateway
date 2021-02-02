using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.Services
{
    public class RoleService : IRoleService
    {

        private readonly HttpClient _httpClient;

        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultModel<string>> AddRole(RoleDto dto)
        {
            var apiJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Role/CreateRole", apiJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> EditRole(RoleDto dto)
        {
            var apiJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Role/UpdateRoles", apiJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public Task<ResultModel<List<RoleDto>>> GetAllRole()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<RoleDto>> GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultModel<PagedList<RoleDto>>> GetRolePage(RoleQueryDto dto)
        {
            var clientJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Role/GetRolesPage", clientJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<PagedList<RoleDto>>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<PagedList<UserRoleDto>>> GetUserRole(UserRoleDto dto)
        {
            var userRoleJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Role/GetUserRolesByUserId", userRoleJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<PagedList<UserRoleDto>>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<List<UserRoleDto>>> GetUserRoleAndIsHaveRoleByUserId(UserRoleDto dto)
        {
            var userRoleJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Role/GetUserRoleAndIsHaveRoleByUserId", userRoleJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<List<UserRoleDto>>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> SetUserRoleByUserIdAndRoleIds(SetUserRoleDto dto)
        {
            var setUserRoleJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Role/SetUserRoleByUserIdAndRoleIds", setUserRoleJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
