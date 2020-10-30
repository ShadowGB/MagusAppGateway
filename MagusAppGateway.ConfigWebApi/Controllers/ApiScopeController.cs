using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace MagusAppGateway.ConfigWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize]
    public class ApiScopeController : Controller
    {
        private readonly IApiScopeService _apiScopeService;

        public ApiScopeController(IApiScopeService apiScopeService)
        {
            _apiScopeService = apiScopeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApiScope([FromBody]ApiScopeCreateDto dto)
        {
            return Json(await _apiScopeService.CreateApiScope(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            return Json(await _apiScopeService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]ApiScopeQueryDto dto)
        {
            return Json(await _apiScopeService.GetList(dto));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIdentityResource([FromBody]ApiScopeUpdateDto dto)
        {
            return Json(await _apiScopeService.UpdateApiScope(dto));
        }
    }
}