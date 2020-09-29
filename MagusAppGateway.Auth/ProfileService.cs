using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.Auth
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
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
