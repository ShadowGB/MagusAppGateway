using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using MagusAppGateway.Models;
using MagusAppGateway.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MagusAppGateway.Auth
{
    public class ProfileService : IProfileService
    {

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public ProfileService(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            #region 旧版本，没有用户验证
            await Task.Run(() =>
               {
                   try
                   {
                       //depending on the scope accessing the user data.
                       var claims = context.Subject.Claims.ToList();
                       //set issued claims to return
                       context.IssuedClaims = claims.ToList();
                   }
                   catch (Exception)
                   {

                   }
               });
            #endregion
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            await Task.Run(() =>
            {
                context.IsActive = true;
            });
        }
    }
}
