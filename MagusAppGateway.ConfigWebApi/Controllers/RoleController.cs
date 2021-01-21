using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace MagusAppGateway.ConfigWebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        /// <summary>
        /// 根据用户ID获取角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string userId)
        {
            return Json(await _roleService.GetRolesByUserId(Guid.Parse(userId)));
        }

        /// <summary>
        /// 根据用户ID获取角色列表
        /// </summary>
        /// <param name="rolesQueryDto">条件模型</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetUserRolesByUserId([FromBody]RolesQueryDto rolesQueryDto)
        {
            return Json(await _roleService.GetUserRolesByUserId(rolesQueryDto));
        }

        /// <summary>
        /// 根据用户ID获取角色和是否有这个角色的列表
        /// </summary>
        /// <param name="rolesQueryDto">条件模型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetUserRoleAndIsHaveRoleByUserId([FromBody]RolesQueryDto rolesQueryDto)
        {
            return Json(await _roleService.GetUserRoleAndIsHaveRoleByUserId(rolesQueryDto));
        }

        /// <summary>
        /// 配置用户角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleIds">角色编号列表</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SetUserRoleByUserIdAndRoleIds([FromBody]SetUserRoleDto dto)
        {
            return Json(await _roleService.SetUserRoleByUserIdAndRoleIds(dto.UserId, dto.RoleIds));
        }
    }
}
