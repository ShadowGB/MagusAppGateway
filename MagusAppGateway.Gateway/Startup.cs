using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Linq;

namespace MagusAppGateway.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();
            var ocelotConfigModel = OcelotConfigJsonToModel.OcelotConfigJsonCoverToModel();
            if (ocelotConfigModel != null)
            {
                foreach (var item in ocelotConfigModel.Routes)
                {
                    if (item.AuthenticationOptions != null)
                    {
                        services.AddAuthentication().AddIdentityServerAuthentication(item.AuthenticationOptions.AuthenticationProviderKey, options =>
                        {
                            options.Authority = Configuration.GetSection("IdentityAddress").Value;
                            options.RequireHttpsMetadata = false;
                            options.SupportedTokens = SupportedTokens.Both;
                        });
                    }
                }
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            IdentityModelEventSource.ShowPII = true;
            app.UseAuthentication();
            app.UseOcelot().Wait();
        }
    }
}
