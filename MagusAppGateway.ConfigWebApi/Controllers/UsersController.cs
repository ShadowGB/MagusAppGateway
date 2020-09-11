using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Models.Dtos;

namespace MagusAppGateway.ConfigWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserCreateDto dto)
        {
            return Json(await _userService.CreateUser(dto));
        }

        [HttpGet]
        public async Task<IActionResult> DisableUser([FromQuery]Guid id)
        {
            return Json(await _userService.DisableUser(id));
        }

        [HttpGet]
        public async Task<IActionResult> EnableUser([FromQuery]Guid id)
        {
            return Json(await _userService.EnableUser(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]Guid id)
        {
            return Json(await _userService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]UserQueryDto dto)
        {
            return Json(await _userService.GetUsers(dto));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody]UserUpdateDto dto)
        {
            return Json(await _userService.UpdateUser(dto));
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ApplyToken([FromBody]ApplyTokenDto dto)
        {
            return Json(await _userService.ApplyToken(dto));
        }
    }
}