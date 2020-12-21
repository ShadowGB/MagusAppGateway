using IdentityServer4.AccessTokenValidation;
using MagusAppGateway.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Ocelot.DependencyInjection;
using MagusAppGateway.Gateway.Extensions;

namespace MagusAppGateway.Gateway
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DBConnection");
            services.AddDbContext<UserDatabaseContext>(options => {
                options.UseNpgsql(connectionString,
                    sql => sql.MigrationsAssembly(typeof(Startup).Assembly.FullName));
            }, ServiceLifetime.Singleton);
            services.AddOcelot().AddOcelotDbConfig(x => x.DbConnectionStrings = connectionString);
            services.AddPostgerSQLAuth(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            IdentityModelEventSource.ShowPII = true;
            app.UseAuthentication();
            app.UsePostgreSQLOcelot().Wait();
        }
    }
}
