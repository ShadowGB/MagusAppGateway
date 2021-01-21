using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using IdentityServer4.EntityFramework.Storage;
using Serilog;
using Microsoft.AspNetCore.Builder;
using MagusAppGateway.Contexts;
using System;
using MagusAppGateway.Models;
using MagusAppGateway.Util;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;

namespace MagusAppGateway.Auth
{
    public static class SeedData
    {
        public static IApplicationBuilder InitData(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var dbcontext = scope.ServiceProvider.GetService<UserDatabaseContext>();
                System.Console.WriteLine("开始执行数据迁移");
                dbcontext.Database.Migrate();

                System.Console.WriteLine("开始创建种子数据");
                var userGuid = Guid.NewGuid();
                var roleGuid = Guid.NewGuid();

                if (!dbcontext.Users.Any())
                {
                    dbcontext.Users.AddRange(
                        new Users
                        {
                            Id = userGuid,
                            Username = "admin",
                            Password = MD5Helper.GetMD5Hash("123456"),
                            Enabled = true
                        });
                }

                if (!dbcontext.Roles.Any())
                {
                    dbcontext.Roles.AddRange(
                        new Roles
                        {
                            Id = roleGuid,
                            RoleName = "admin"
                        });
                }

                if (!dbcontext.UserRoles.Any())
                {
                    dbcontext.UserRoles.AddRange(
                        new UserRole
                        {
                            Id = new Guid(),
                            RoleId = roleGuid,
                            UserId = userGuid
                        });
                }

                if (!dbcontext.ApiScopes.Any())
                {
                    dbcontext.ApiScopes.AddRange(
                        new IdentityServer4.EntityFramework.Entities.ApiScope
                        {
                            Id = 1,
                            Enabled = true,
                            Name = "testapi",
                            DisplayName = "Test API",
                            Description = "这是一个测试API",
                            Required = false,
                            Emphasize = false,
                            ShowInDiscoveryDocument = true
                        },
                        new IdentityServer4.EntityFramework.Entities.ApiScope
                        {
                            Id = 2,
                            Enabled = true,
                            Name = "config",
                            DisplayName = "Config Interface",
                            Description = "配置接口",
                            Required = false,
                            Emphasize = false,
                            ShowInDiscoveryDocument = true
                        });
                }

                var testClientId = 1;
                var wasmClientId = 2;

                if (!dbcontext.Clients.Any())
                {
                    dbcontext.Clients.AddRange(
                        new IdentityServer4.EntityFramework.Entities.Client
                        {
                            Id = testClientId,
                            Enabled = true,
                            ClientId = "TestClient",
                            ProtocolType = "oidc",
                            RequireClientSecret = true,
                            ClientName = "Test Client",
                            Description = "测试客户端",
                            RequireConsent = false,
                            AllowRememberConsent = true,
                            AlwaysIncludeUserClaimsInIdToken = true,
                            RequirePkce = true,
                            AllowPlainTextPkce = true,
                            RequireRequestObject = false,
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
                        },
                        new IdentityServer4.EntityFramework.Entities.Client
                        {
                            Id = wasmClientId,
                            ClientId = "WasmClient",
                            ClientName = "Wasm Client",
                            Description = "管理平台前端",
                            RequireClientSecret = false
                        });
                }

                if (!dbcontext.ClientCorsOrigins.Any())
                {
                    dbcontext.ClientCorsOrigins.AddRange(
                        new ClientCorsOrigin
                        {
                            Id = 1,
                            Origin = "http://127.0.0.1:5002",
                            ClientId = testClientId
                        },
                        new ClientCorsOrigin
                        {
                            Id = 2,
                            Origin = "http://127.0.0.1:5003",
                            ClientId = wasmClientId
                        });
                }

                if (!dbcontext.ClientGrantTypes.Any())
                {
                    List<ClientGrantType> clientGrantTypes = new List<ClientGrantType>();
                    var id = 1;
                    foreach (var item in GrantTypes.ResourceOwnerPassword)
                    {
                        clientGrantTypes.Add(new ClientGrantType
                        {
                            Id = id,
                            GrantType = item,
                            ClientId = testClientId
                        });
                        id++;
                    }
                    foreach (var item in GrantTypes.ClientCredentials)
                    {
                        clientGrantTypes.Add(new ClientGrantType
                        {
                            Id = id,
                            GrantType = item,
                            ClientId = testClientId
                        });
                        id++;
                    }

                    foreach (var item in GrantTypes.Code)
                    {
                        clientGrantTypes.Add(new ClientGrantType
                        {
                            Id = id,
                            GrantType = item,
                            ClientId = wasmClientId
                        });
                        id++;
                    }

                    dbcontext.ClientGrantTypes.AddRange(clientGrantTypes);
                }

                if (!dbcontext.ClientPostLogoutRedirectUris.Any())
                {
                    dbcontext.ClientPostLogoutRedirectUris.AddRange(
                        new ClientPostLogoutRedirectUri
                        {
                            Id = 1,
                            PostLogoutRedirectUri = "http://127.0.0.1:5001/logout",
                            ClientId = testClientId
                        },
                        new ClientPostLogoutRedirectUri
                        {
                            Id = 2,
                            PostLogoutRedirectUri = "http://127.0.0.1:5003/",
                            ClientId = wasmClientId
                        });
                }

                if (!dbcontext.ClientRedirectUris.Any())
                {
                    dbcontext.ClientRedirectUris.AddRange(
                        new ClientRedirectUri
                        {
                            Id = 1,
                            RedirectUri = "http://127.0.0.1:5001/login",
                            ClientId = testClientId
                        },
                        new ClientRedirectUri
                        {
                            Id = 2,
                            RedirectUri = "http://127.0.0.1:5003/authentication/login-callback",
                            ClientId = wasmClientId
                        });
                }

                if (!dbcontext.ClientScopes.Any())
                {
                    dbcontext.ClientScopes.AddRange(
                        new ClientScope
                        {
                            Id = 1,
                            Scope = "openid",
                            ClientId = testClientId
                        },
                        new ClientScope
                        {
                            Id = 2,
                            Scope = "profile",
                            ClientId = testClientId
                        },
                        new ClientScope
                        {
                            Id = 3,
                            Scope = "testapi",
                            ClientId = testClientId
                        },
                        new ClientScope
                        {
                            Id = 4,
                            Scope = "config",
                            ClientId = testClientId
                        }, new ClientScope
                        {
                            Id = 5,
                            Scope = "openid",
                            ClientId = wasmClientId
                        },
                        new ClientScope
                        {
                            Id = 6,
                            Scope = "profile",
                            ClientId = wasmClientId
                        },
                        new ClientScope
                        {
                            Id = 7,
                            Scope = "config",
                            ClientId = wasmClientId
                        });
                }

                if (!dbcontext.ClientSecrets.Any())
                {
                    dbcontext.ClientSecrets.AddRange(
                        new ClientSecret
                        {
                            Id = 1,
                            Description = "测试秘钥",
                            Value = "123".ToSha256(),
                            Expiration = DateTime.Now.AddYears(1),
                            Type = "SharedSecret",
                            Created = DateTime.Now,
                            ClientId = testClientId
                        });
                }

                if(!dbcontext.IdentityResources.Any())
                {
                    dbcontext.IdentityResources.AddRange(
                        new IdentityServer4.EntityFramework.Entities.IdentityResource
                        {
                            Id = 1,
                            Enabled = true,
                            Name = "profile",
                            DisplayName = "User profile",
                            Description = "Your user profile information (first name, last name, etc.)",
                            Required = false,
                            Emphasize = true,
                            ShowInDiscoveryDocument = true,
                            Created = DateTime.Now,
                            Updated = DateTime.Now,
                            NonEditable = false
                        },
                        new IdentityServer4.EntityFramework.Entities.IdentityResource
                        {
                            Id = 2,
                            Enabled = true,
                            Name = "openid",
                            DisplayName = "Your user identifier",
                            Description = "Your user profile information (first name, last name, etc.)",
                            Required = false,
                            Emphasize = true,
                            ShowInDiscoveryDocument = true,
                            Created = DateTime.Now,
                            Updated = DateTime.Now,
                            NonEditable = false
                        });
                }

                var ocelotGuid = Guid.NewGuid();
                var routesGuid = Guid.NewGuid();

                if (!dbcontext.OcelotConfigs.Any())
                {
                    dbcontext.OcelotConfigs.AddRange(
                        new OcelotConfig
                        {
                            Id = ocelotGuid,
                            IsEnable = true
                        });
                }

                if (!dbcontext.GlobalConfigurations.Any())
                {
                    dbcontext.GlobalConfigurations.AddRange(
                        new GlobalConfiguration
                        {
                            Id = ocelotGuid,
                            BaseUrl = "http://127.0.0.1:5002",
                            OcelotConfigGuid = ocelotGuid
                        });
                }

                if (!dbcontext.Routes.Any())
                {
                    dbcontext.Routes.AddRange(
                        new Routes
                        {
                            Id = routesGuid,
                            DownstreamPathTemplate = "/api/{everything}",
                            DownstreamScheme = "http",
                            UpstreamPathTemplate = "/api/{everything}",
                            RouteIsCaseSensitive = false,
                            OcelotConfigGuid = ocelotGuid
                        });
                }

                if (!dbcontext.DownstreamHostAndPorts.Any())
                {
                    dbcontext.DownstreamHostAndPorts.AddRange(
                        new DownstreamHostAndPorts { Host = "127.0.0.1", Port = 1001, Id = Guid.NewGuid(), RoutesGuid = routesGuid },
                        new DownstreamHostAndPorts { Host = "127.0.0.1", Port = 1002, Id = Guid.NewGuid(), RoutesGuid = routesGuid });
                }

                if (!dbcontext.AuthenticationOptions.Any())
                {
                    dbcontext.AuthenticationOptions.AddRange(
                        new AuthenticationOptions { AuthenticationProviderKey = "testapi", Id = Guid.NewGuid(), RoutesGuid = routesGuid });
                }

                if (!dbcontext.LoadBalancerOptions.Any())
                {
                    dbcontext.LoadBalancerOptions.AddRange(
                        new LoadBalancerOption { Type = "RoundRobin", Id = Guid.NewGuid(), RoutesGuid = routesGuid });
                }

                if(!dbcontext.UpstreamHttpMethods.Any())
                {
                    dbcontext.UpstreamHttpMethods.AddRange(
                        new UpstreamHttpMethods { Id = Guid.NewGuid(), Method = "Get", RoutesGuid = routesGuid },
                        new UpstreamHttpMethods { Id = Guid.NewGuid(), Method = "Post", RoutesGuid = routesGuid });
                }

                dbcontext.SaveChangesAsync();

                System.Console.WriteLine("数据库迁移完成");
            }
            return builder;
        }
    }
}
