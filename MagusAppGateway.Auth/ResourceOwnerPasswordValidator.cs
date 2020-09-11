using IdentityServer4.Validation;
using System.Threading.Tasks;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Services.IServices;
using IdentityServer4.Models;
using System.Collections.Generic;
using MagusAppGateway.Models;
using System.Security.Claims;
using IdentityModel;

namespace MagusAppGateway.Auth
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;

        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
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

            if (result.status.code != Services.Result.ResultCode.Success)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, result.status.text);
            }
            else
            {

                var data = result.custom as Users;
                var claim = new Claim[]
                {
                    new Claim(JwtClaimTypes.Id, data.Id.ToString()),
                    new Claim(JwtClaimTypes.Name, data.Username??string.Empty),
                };
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
