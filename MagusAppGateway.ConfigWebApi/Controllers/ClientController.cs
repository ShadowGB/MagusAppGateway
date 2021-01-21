using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace MagusAppGateway.ConfigWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// 新增客户端
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody]ClientEditDto dto)
        {
            return Json(await _clientService.CreateClient(dto));
        }

        /// <summary>
        /// 根据ID获取客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            return Json(await _clientService.GetById(id));
        }

        /// <summary>
        /// 查询客户端
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetPageList([FromBody]ClientQueryDto dto)
        {
            return Json(await _clientService.GetList(dto));
        }

        /// <summary>
        /// 更新客户端
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateClient([FromBody]ClientEditDto dto)
        {
            return Json(await _clientService.UpdateClient(dto));
        }

        /// <summary>
        /// 客户端跨域配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ConfigClientCorsOrigin([FromBody]ClientCorsOriginConfigDto dto)
        {
            return Json(await _clientService.ConfigClientCorsOrigin(dto.clientCorsOriginEditDtos, dto.ClientId));
        }

        /// <summary>
        /// 客户端授权方式配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ConfigClientGrantType([FromBody]ClientGrantTypeConfigDto dto)
        {
            return Json(await _clientService.ConfigClientGrantType(dto.clientGrantTypeEditDtos, dto.ClientId));
        }

        /// <summary>
        /// 客户端登出回调地址配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ConfigClientPostLogoutRedirectUri([FromBody]ClientPostLogoutRedirectUriConfigDto dto)
        {
            return Json(await _clientService.ConfigClientPostLogoutRedirectUri(dto.clientPostLogoutRedirectUriEditDtos, dto.ClientId));
        }

        /// <summary>
        /// 客户端登录回调地址配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ConfigClientRedirectUri([FromBody]ClientRedirectUriConfigDto dto)
        {
            return Json(await _clientService.ConfigClientRedirectUri(dto.clientRedirectUriEditDtos, dto.ClientId));
        }

        /// <summary>
        /// 客户端API域配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ConfigClientScope([FromBody]ClientScopeConfigDto dto)
        {
            return Json(await _clientService.ConfigClientScope(dto.clientScopeEditDtos, dto.ClientId));
        }

        /// <summary>
        /// 客户端秘钥配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ConfigClientSecret([FromBody]ClientSecretConfigDto dto)
        {
            return Json(await _clientService.ConfigClientSecret(dto.clientSecretEditDtos, dto.ClientId));
        }
    }
}