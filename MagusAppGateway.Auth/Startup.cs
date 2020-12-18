using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Services.Services;
using MagusAppGateway.Contexts;
using MagusAppGateway.Services.Automapper;
using AutoMapper;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.PlatformAbstractions;

namespace MagusAppGateway.Auth
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
            services.AddControllersWithViews();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(AutomapperConfig));
            var connectionString = Configuration.GetConnectionString("DBConnection");
            services.AddDbContext<UserDatabaseContext>(
                options =>
                {
                    //options.EnableSensitiveDataLogging(true);
                    options.UseNpgsql(connectionString);
                },ServiceLifetime.Singleton);

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
                //options.IssuerUri = Configuration.GetSection("urls").Value;
            })
                .AddProfileService<ProfileService>()
                //Fuck of the test user
                //.AddTestUsers(TestUsers.Users)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString);
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString);
                    options.EnableTokenCleanup = true;
                })
            .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                builder
                    .AddSigningCredential(new X509Certificate2(Path.Combine(basePath,
                    Configuration["Certificates:CerPath"]),
                    Configuration["Certificates:Password"]));
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
