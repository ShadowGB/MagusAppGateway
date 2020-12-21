using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Entities;
using MagusAppGateway.Models;
using System;
using IdentityModel;
using MagusAppGateway.Util;
using System.Collections.Generic;

namespace MagusAppGateway.Contexts
{
    public class UserDatabaseContext : DbContext
    {
        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //用户表主键
            modelBuilder.Entity<Users>().HasKey(x => x.Id);
            //身份认证资源
            modelBuilder.Entity<IdentityResourceProperty>().HasOne(x => x.IdentityResource).WithMany(x => x.Properties).HasForeignKey(x => x.IdentityResourceId);
            modelBuilder.Entity<IdentityResourceClaim>().HasOne(x => x.IdentityResource).WithMany(x => x.UserClaims).HasForeignKey(x => x.IdentityResourceId);
            //API
            modelBuilder.Entity<ApiScopeClaim>().HasOne(x => x.Scope).WithMany(x => x.UserClaims).HasForeignKey(x => x.ScopeId);
            //modelBuilder.Entity<ApiScopeProperty>().HasOne(x =>x.Scope).WithMany(x => x.Properties).HasForeignKey(x => x.ScopeId);
            //Client
            modelBuilder.Entity<ClientIdPRestriction>().HasOne(x => x.Client).WithMany(x => x.IdentityProviderRestrictions).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientClaim>().HasOne(x => x.Client).WithMany(x => x.Claims).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientCorsOrigin>().HasOne(x => x.Client).WithMany(x => x.AllowedCorsOrigins).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientProperty>().HasOne(x => x.Client).WithMany(x => x.Properties).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientScope>().HasOne(x => x.Client).WithMany(x => x.AllowedScopes).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientSecret>().HasOne(x => x.Client).WithMany(x => x.ClientSecrets).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientGrantType>().HasOne(x => x.Client).WithMany(x => x.AllowedGrantTypes).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientRedirectUri>().HasOne(x => x.Client).WithMany(x => x.RedirectUris).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientPostLogoutRedirectUri>().HasOne(x => x.Client).WithMany(x => x.PostLogoutRedirectUris).HasForeignKey(x => x.ClientId);
            //Ocelot
            modelBuilder.Entity<DownstreamHostAndPorts>().HasOne(x => x.Routes).WithMany(x => x.DownstreamHostAndPorts).HasForeignKey(x => x.RoutesGuid);
            modelBuilder.Entity<Routes>().HasOne(x => x.OcelotConfig).WithMany(x => x.Routes).HasForeignKey(x => x.OcelotConfigGuid);
            modelBuilder.Entity<AuthenticationOptions>().HasOne(x => x.Routes).WithOne(x => x.AuthenticationOptions).HasForeignKey<Routes>(x => x.Guid).HasPrincipalKey<AuthenticationOptions>(x => x.RoutesGuid);
            modelBuilder.Entity<LoadBalancerOption>().HasOne(x => x.Routes).WithOne(x => x.LoadBalancerOption).HasForeignKey<Routes>(x => x.Guid).HasPrincipalKey<LoadBalancerOption>(x => x.RoutesGuid);
            modelBuilder.Entity<GlobalConfiguration>().HasOne(x => x.OcelotConfig).WithOne(x => x.GlobalConfiguration).HasForeignKey<GlobalConfiguration>(x => x.OcelotConfigGuid).HasPrincipalKey<OcelotConfig>(x => x.Guid);

            modelBuilder.Entity<OcelotConfig>().HasKey(x => x.Guid);
            modelBuilder.Entity<Routes>().HasKey(x => x.Guid);
            modelBuilder.Entity<GlobalConfiguration>().HasKey(x => x.Guid);
            modelBuilder.Entity<AuthenticationOptions>().HasKey(x => x.Guid);
            modelBuilder.Entity<LoadBalancerOption>().HasKey(x => x.Guid);

            modelBuilder.Entity<ApiScope>().HasData(
                new ApiScope
                {
                    Id = 1,
                    Enabled = true,
                    Name = "api1",
                    DisplayName = "Test API",
                    Description = "这是一个测试API",
                    Required = false,
                    Emphasize = false,
                    ShowInDiscoveryDocument = true
                },
                new ApiScope
                {
                    Id = 2,
                    Enabled = true,
                    Name = "config",
                    DisplayName = "Config Center",
                    Description = "配置中心",
                    Required = false,
                    Emphasize = false,
                    ShowInDiscoveryDocument = true
                });

            var clientId = 1;

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = clientId,
                    Enabled = true,
                    ClientId = "mvc",
                    ProtocolType = "oidc",
                    RequireClientSecret = true,
                    ClientName = "mvc client",
                    Description = "MVC客户端",
                    RequireConsent = false,
                    AllowRememberConsent = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RequirePkce = true,
                    AllowPlainTextPkce = true,
                    RequireRequestObject = true,
                    AllowAccessTokensViaBrowser = true,
                    FrontChannelLogoutSessionRequired = true,
                    BackChannelLogoutSessionRequired = true,
                    AllowOfflineAccess = true,
                    IdentityTokenLifetime = 300,
                    AccessTokenLifetime = 3600,
                    AuthorizationCodeLifetime = 300,
                    AbsoluteRefreshTokenLifetime = 2592000,
                    SlidingRefreshTokenLifetime = 1296000,
                    RefreshTokenUsage = 1,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RefreshTokenExpiration = 1,
                    AccessTokenType = 0,
                    EnableLocalLogin = true,
                    IncludeJwtId = true,
                    AlwaysSendClientClaims = true,
                    ClientClaimsPrefix = "client_",
                    Created = DateTime.Now,
                    DeviceCodeLifetime = 300,
                    NonEditable = false
                });

            modelBuilder.Entity<ClientCorsOrigin>().HasData(
                new ClientCorsOrigin
                {
                    Id = 1,
                    Origin = "http://127.0.0.1:5002",
                    ClientId = clientId
                });

            modelBuilder.Entity<ClientGrantType>().HasData(
                new ClientGrantType
                {
                    Id = 1,
                    GrantType = "password",
                    ClientId = clientId
                },
                new ClientGrantType
                {
                    Id = 2,
                    GrantType = "client_credentials",
                    ClientId = clientId
                });

            modelBuilder.Entity<ClientPostLogoutRedirectUri>().HasData(
                new ClientPostLogoutRedirectUri
                {
                    Id = 1,
                    PostLogoutRedirectUri = "http://127.0.0.1:5001/logout",
                    ClientId = clientId
                });

            modelBuilder.Entity<ClientRedirectUri>().HasData(
                new ClientRedirectUri
                {
                    Id = 1,
                    RedirectUri = "http://127.0.0.1:5001/login",
                    ClientId = clientId
                });

            modelBuilder.Entity<ClientScope>().HasData(
                new ClientScope
                {
                    Id = 1,
                    Scope = "openid",
                    ClientId = clientId
                },
                new ClientScope
                {
                    Id = 2,
                    Scope = "profile",
                    ClientId = clientId
                },
                new ClientScope
                {
                    Id = 3,
                    Scope = "api1",
                    ClientId = clientId
                },
                new ClientScope
                {
                    Id = 4,
                    Scope = "config",
                    ClientId = clientId
                });

            modelBuilder.Entity<ClientSecret>().HasData(
                new ClientSecret
                {
                    Id = 1,
                    Description = "测试",
                    Value = "123".ToSha256(),
                    Expiration = DateTime.Now.AddYears(1),
                    Type = "SharedSecret",
                    Created = DateTime.Now,
                    ClientId = clientId
                });

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = Guid.NewGuid(),
                    Username = "admin",
                    Password = MD5Helper.GetMD5Hash("123456"),
                    Enabled = true
                });

            var ocelotGuid = Guid.NewGuid();
            var routesGuid = Guid.NewGuid();

            modelBuilder.Entity<OcelotConfig>().HasData(
                new OcelotConfig
                {
                    Guid = ocelotGuid,
                    IsEnable = true
                });


            modelBuilder.Entity<GlobalConfiguration>().HasData(
                new GlobalConfiguration
                {
                    Guid = ocelotGuid,
                    BaseUrl = "http://127.0.0.1:5002",
                    OcelotConfigGuid = ocelotGuid
                });

            modelBuilder.Entity<Routes>().HasData(new Routes
            {
                Guid = routesGuid,
                DownstreamPathTemplate = "/api/{everything}",
                //DownstreamHostAndPorts = new List<DownstreamHostAndPorts> {
                //        new DownstreamHostAndPorts{ Host="127.0.0.1",Port=1001,Guid=Guid.NewGuid() },
                //        new DownstreamHostAndPorts{ Host="127.0.0.1",Port=1002,Guid=Guid.NewGuid() }
                //    },
                //UpstreamHttpMethod = new List<string> { "Get", "Post" },
                //LoadBalancerOption = new LoadBalancerOption { Type = "RoundRobin", Guid = Guid.NewGuid(),RoutesGuid=routesGuid },
                DownstreamScheme = "http",
                UpstreamPathTemplate = "/api/{everything}",
                RouteIsCaseSensitive = false,
                //AuthenticationOptions = new AuthenticationOptions { AuthenticationProviderKey = "api1", Guid = Guid.NewGuid(), AllowedScopes = new List<string> { } },
                OcelotConfigGuid = ocelotGuid
            });

            modelBuilder.Entity<DownstreamHostAndPorts>().HasData(
                new DownstreamHostAndPorts { Host = "127.0.0.1", Port = 1001, Guid = Guid.NewGuid(), RoutesGuid = routesGuid },
                new DownstreamHostAndPorts { Host = "127.0.0.1", Port = 1002, Guid = Guid.NewGuid(), RoutesGuid = routesGuid });

            modelBuilder.Entity<AuthenticationOptions>().HasData(
                new AuthenticationOptions { AuthenticationProviderKey = "api1", Guid = Guid.NewGuid(), RoutesGuid = routesGuid });

            modelBuilder.Entity<LoadBalancerOption>().HasData(
                new LoadBalancerOption { Type = "RoundRobin", Guid = Guid.NewGuid(), RoutesGuid = routesGuid });


            modelBuilder.Entity<UpstreamHttpMethods>().HasData(
                new UpstreamHttpMethods { Guid = Guid.NewGuid(), Method = "Get", RoutesGuid = routesGuid },
                new UpstreamHttpMethods { Guid = Guid.NewGuid(), Method = "Post", RoutesGuid = routesGuid }
                );
        }

        public DbSet<Users> Users { get; set; }

        #region 身份资源
        public DbSet<IdentityResource> IdentityResources { get; set; }

        public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }

        public DbSet<IdentityResourceClaim> IdentityResourceClaims { get; set; }
        #endregion

        #region API
        public DbSet<ApiScope> ApiScopes { get; set; }

        public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }

        public DbSet<ApiResourceProperty> ApiScopeProperties { get; set; }
        #endregion

        #region Client
        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }

        public DbSet<ClientClaim> ClientClaims { get; set; }

        public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }

        public DbSet<ClientProperty> ClientProperties { get; set; }

        public DbSet<ClientScope> ClientScopes { get; set; }

        public DbSet<ClientSecret> ClientSecrets { get; set; }

        public DbSet<ClientGrantType> ClientGrantTypes { get; set; }

        public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }

        public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        #endregion

        #region Ocelot配置
        public DbSet<OcelotConfig> OcelotConfigs { get; set; }

        public DbSet<GlobalConfiguration> GlobalConfigurations { get; set; }

        public DbSet<Routes> Routes { get; set; }

        public DbSet<LoadBalancerOption> LoadBalancerOptions { get; set; }

        public DbSet<AuthenticationOptions> AuthenticationOptions { get; set; }

        public DbSet<DownstreamHostAndPorts> DownstreamHostAndPorts { get; set; }
        #endregion
    }
}
