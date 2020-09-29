using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.OpenApi.Models;
using MagusAppGateway.Contexts;
using MagusAppGateway.Services.Services;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Services.Automapper;
using Microsoft.IdentityModel.Tokens;

namespace MagusAppGateway.ConfigWebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DBConnection");
            services.AddControllers();
            services.AddDbContext<UserDatabaseContext>(options => {
                options.UseNpgsql(connectionString, 
                    sql => sql.MigrationsAssembly(typeof(Startup).Assembly.FullName));
            },ServiceLifetime.Singleton);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdentityResourceService, IdentityResourceService>();
            services.AddScoped<IApiScopeService, ApiScopeService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddAutoMapper(typeof(AutomapperConfig));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "配置中心", Version = "v1" });
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = _configuration.GetSection("IdentityAddress").Value;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options => {
                options.AddPolicy("ApiScope", policy => {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", _configuration.GetSection("ScopeName").Value);
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "配置中心");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
