using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;

namespace MagusAppGateway.ConfigWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class OcelotController : Controller
    {
        private readonly IOcelotConfigService _ocelotConfigService;

        public OcelotController(IOcelotConfigService ocelotConfigService)
        {
            _ocelotConfigService = ocelotConfigService;
        }

        /// <summary>
        /// 创建配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateConfig([FromBody]OcelotConfigEditDto dto)
        {
            return Json(await _ocelotConfigService.CreateConfig(dto));
        }

        /// <summary>
        /// 创建路由
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRoute([FromBody]RoutesEditDto dto)
        {
            return Json(await _ocelotConfigService.CreateRoute(dto));
        }

        /// <summary>
        /// 删除配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteConfig([FromQuery]Guid id)
        {
            return Json(await _ocelotConfigService.DeleteConfig(id));
        }

        /// <summary>
        /// 删除路由
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DelteRoute([FromQuery]Guid id)
        {
            return Json(await _ocelotConfigService.DelteRoute(id));
        }

        /// <summary>
        /// 启用配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> EnableConfig([FromQuery]Guid id)
        {
            return Json(await _ocelotConfigService.EnableConfig(id));
        }

        /// <summary>
        /// 获取配置列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetConfigPageList([FromBody]OcelotConfigQueryDto dto)
        {
            return Json(await _ocelotConfigService.GetConfigPageList(dto));
        }

        /// <summary>
        /// 根据编号获取路由
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRouteById([FromQuery]Guid id)
        {
            return Json(await _ocelotConfigService.GetRouteById(id));
        }

        /// <summary>
        /// 获取路由列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetRoutePageList([FromBody]RoutesQueryDto dto)
        {
            return Json(await _ocelotConfigService.GetRoutePageList(dto));
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateConfig([FromBody]OcelotConfigEditDto dto)
        {
            return Json(await _ocelotConfigService.UpdateConfig(dto));
        }

        /// <summary>
        /// 更新路由
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateRoute([FromBody]RoutesEditDto dto)
        {
            return Json(await _ocelotConfigService.UpdateRoute(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetConfigById([FromQuery]Guid id)
        {
            return Json(await _ocelotConfigService.GetConfigById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConfig()
        {
            return Json(await _ocelotConfigService.GetAllConfig());
        }
    }
}
