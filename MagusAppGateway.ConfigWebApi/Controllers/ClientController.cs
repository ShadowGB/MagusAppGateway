using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Models.Dtos;

namespace MagusAppGateway.ConfigWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody]ClientCreateDto dto)
        {
            return Json(await _clientService.CreateClient(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            return Json(await _clientService.GetById(id));
        }



        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]ClientQueryDto dto)
        {
            return Json(await _clientService.GetList(dto));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClient([FromBody]ClientUpdateDto dto)
        {
            return Json(await _clientService.UpdateClient(dto));
        }
    }
}