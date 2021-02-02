using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.ViewModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MagusAppGateway.UI.Result;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace MagusAppGateway.UI.Services
{
    public class OcelotService : IOcelotService
    {
        private readonly HttpClient _httpClient;

        public OcelotService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultModel<string>> CreateConfig(OcelotConfigEditDto dto)
        {
            var configJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Ocelot/CreateConfig", configJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> CreateRoute(RoutesEditDto dto)
        {
            var routeJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Ocelot/CreateRoute", routeJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> DeleteConfig(Guid id)
        {
            return JsonConvert.DeserializeObject<ResultModel<string>>(
               await _httpClient.GetStringAsync($"/api/Ocelot/DeleteConfig?id={id}"));
        }

        public async Task<ResultModel<string>> DelteRoute(Guid id)
        {
            return JsonConvert.DeserializeObject<ResultModel<string>>(
               await _httpClient.GetStringAsync($"/api/Ocelot/DelteRoute?id={id}"));
        }

        public async Task<ResultModel<string>> EnableConfig(Guid id)
        {
            return JsonConvert.DeserializeObject<ResultModel<string>>(
               await _httpClient.GetStringAsync($"/api/Ocelot/EnableConfig?id={id}"));
        }

        public async Task<ResultModel<List<OcelotConfigDto>>> GetAllConfig()
        {
            return JsonConvert.DeserializeObject<ResultModel<List<OcelotConfigDto>>>(
               await _httpClient.GetStringAsync($"/api/Ocelot/GetAllConfig"));
        }

        public async Task<ResultModel<OcelotConfigDto>> GetConfigById(Guid id)
        {
            return JsonConvert.DeserializeObject<ResultModel<OcelotConfigDto>>(
               await _httpClient.GetStringAsync($"/api/Ocelot/GetConfigById?id={id}"));
        }

        public async Task<ResultModel<PagedList<OcelotConfigDto>>> GetConfigPageList(OcelotConfigQueryDto dto)
        {
            var routeJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Ocelot/GetConfigPageList", routeJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<PagedList<OcelotConfigDto>>> (await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<RoutesDto>> GetRouteById(Guid id)
        {
            return JsonConvert.DeserializeObject<ResultModel<RoutesDto>>(
               await _httpClient.GetStringAsync($"/api/Ocelot/GetRouteById?id={id}"));
        }

        public async Task<ResultModel<PagedList<RoutesDto>>> GetRoutePageList(RoutesQueryDto dto)
        {
            var routeJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Ocelot/GetRoutePageList", routeJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<PagedList<RoutesDto>>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> UpdateConfig(OcelotConfigEditDto dto)
        {
            var routeJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Ocelot/UpdateConfig", routeJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<ResultModel<string>> UpdateRoute(RoutesEditDto dto)
        {
            var routeJson = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Ocelot/UpdateRoute", routeJson);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultModel<string>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
