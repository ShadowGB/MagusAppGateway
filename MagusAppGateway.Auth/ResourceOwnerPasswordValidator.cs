using IdentityServer4.Validation;
using System.Threading.Tasks;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Services.IServices;
using IdentityServer4.Models;
using System.Collections.Generic;
using MagusAppGateway.Models;
using System.Security.Claims;
using IdentityModel;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Auth
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public ResourceOwnerPasswordValidator(IUserService userService,IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            UserLoginDto loginDto = new UserLoginDto()
            {
                Password = context.Password,
                Username = context.UserName,
                ClientId = context.Request.Client.ClientId
            };
            var result = await _userService.Login(loginDto);

            if (result.status.code != ResultCode.Success)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, result.status.text);
            }
            else
            {

                var data = result.custom as Users;

                var claim = new Claim[2];
                claim[0] = new Claim(JwtClaimTypes.Id, data.Id.ToString());
                claim[1] = new Claim(JwtClaimTypes.Name, data.Username ?? string.Empty);

                var rolesData = await _roleService.GetRolesByUserId(data.Id);
                if (rolesData.status.code == ResultCode.Success)
                {
                    var roles = rolesData.custom as List<Roles>;
                    claim = new Claim[2 + roles.Count];
                    claim[0] = new Claim(JwtClaimTypes.Id, data.Id.ToString());
                    claim[1] = new Claim(JwtClaimTypes.Name, data.Username ?? string.Empty);
                    roles.ForEach(
                        x =>
                        {
                            int index = 2;
                            claim[index] = new Claim(JwtClaimTypes.Role, x.RoleName);
                            index++;
                        });
                }


                Dictionary<string, object> user = new Dictionary<string, object>();
                user.Add("user", data);
                context.Result = new GrantValidationResult(
                 subject: context.UserName,
                 authenticationMethod: "custom",
                 claims: claim,
                 customResponse: user);
            }
        }
    }
}
