using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using MagusAppGateway.Contexts;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MagusAppGateway.Gateway.Extensions
{
    public static class AddDbAuth
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            // 构建一个服务的提供程序
            var provider = services.BuildServiceProvider();

            var context = provider.GetRequiredService<UserDatabaseContext>();

            var ocelotConfig = context.OcelotConfigs.FirstOrDefault(x => x.IsEnable == true);
            var routes = context.Routes.Where(x => x.OcelotConfigGuid == ocelotConfig.Id).Include(x => x.AuthenticationOptions);

            if (routes != null)
            {
                foreach (var item in routes)
                {
                    if (item.AuthenticationOptions != null)
                    {
                        services.AddAuthentication().AddIdentityServerAuthentication(item.AuthenticationOptions.AuthenticationProviderKey, options =>
                        {
                            options.Authority = configuration.GetSection("IdentityAddress").Value;
                            options.RequireHttpsMetadata = false;
                            options.SupportedTokens = SupportedTokens.Both;
                        });
                    }
                }
            }

            return services;
        }
    }
}
