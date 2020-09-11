using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Models.Dtos;

namespace MagusAppGateway.ConfigWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityResourceController : Controller
    {
        private readonly IIdentityResourceService _identityResourceService;

        public IdentityResourceController(IIdentityResourceService identityResourceService)
        {
            _identityResourceService = identityResourceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIdentityResource([FromBody]IdentityResourceCreateDto dto)
        {
            return Json(await _identityResourceService.CreateIdentityResource(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            return Json(await _identityResourceService.GetById(id));
        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]IdentityResourceQueryDto dto)
        {
            return Json(await _identityResourceService.GetList(dto));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIdentityResource([FromBody]IdentityResourceUpdateDto dto)
        {
            return Json(await _identityResourceService.UpdateIdentityResource(dto));
        }
    }
}