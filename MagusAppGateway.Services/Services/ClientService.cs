using System;
using System.Linq;
using System.Threading.Tasks;
using MagusAppGateway.Services.IServices;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using IdentityServer4.Models;
using MagusAppGateway.Contexts;
using MagusAppGateway.Models.Dtos;
using IdentityModel;
using MagusAppGateway.Util.Result;
using MagusAppGateway.Models;

namespace MagusAppGateway.Services.Services
{
    public class ClientService:IClientService
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public ClientService(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        public async Task<ResultModel> ConfigClientCorsOrigin(List<ClientCorsOriginEditDto> clientCorsOriginCreateDtos, int clientId)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == clientId)
                  .Include(x => x.AllowedCorsOrigins)
                  .FirstOrDefaultAsync();

            List<ClientCorsOrigin> clientCorsOrigins = new List<ClientCorsOrigin>();
            foreach (var item in clientCorsOriginCreateDtos)
            {
                clientCorsOrigins.Add(new ClientCorsOrigin
                {
                    Origin = item.Origin
                });
            }
            client.AllowedCorsOrigins = clientCorsOrigins;
            try
            {
                _userDatabaseContext.Clients.Update(client);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新客户端跨域配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> ConfigClientGrantType(List<ClientGrantTypeEditDto> clientGrantTypeCreateDtos, int clientId)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == clientId)
                     .Include(x => x.AllowedGrantTypes)
                     .FirstOrDefaultAsync();

            List<ClientGrantType> clientGrantTypes = new List<ClientGrantType>();
            foreach (var item in clientGrantTypeCreateDtos)
            {
                clientGrantTypes.Add(new ClientGrantType
                {
                    GrantType = item.GrantType
                });
            }
            client.AllowedGrantTypes = clientGrantTypes;
            try
            {
                _userDatabaseContext.Clients.Update(client);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新客户端授权配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> ConfigClientPostLogoutRedirectUri(List<ClientPostLogoutRedirectUriEditDto> clientPostLogoutRedirectUriCreateDtos, int clientId)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == clientId)
                     .Include(x => x.PostLogoutRedirectUris)
                     .FirstOrDefaultAsync();

            List<ClientPostLogoutRedirectUri> clientPostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>();
            foreach (var item in clientPostLogoutRedirectUriCreateDtos)
            {
                clientPostLogoutRedirectUris.Add(new ClientPostLogoutRedirectUri
                {
                    PostLogoutRedirectUri = item.PostLogoutRedirectUri
                });
            }
            client.PostLogoutRedirectUris = clientPostLogoutRedirectUris;
            try
            {
                _userDatabaseContext.Clients.Update(client);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新客户端登出回调地址配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> ConfigClientRedirectUri(List<ClientRedirectUriEditDto> clientRedirectUriCreateDtos, int clientId)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == clientId)
                        .Include(x => x.RedirectUris)
                        .FirstOrDefaultAsync();


            List<ClientRedirectUri> clientRedirectUris = new List<ClientRedirectUri>();
            foreach (var item in clientRedirectUriCreateDtos)
            {
                clientRedirectUris.Add(new ClientRedirectUri
                {
                    RedirectUri = item.RedirectUri
                });
            }
            client.RedirectUris = clientRedirectUris;
            try
            {
                _userDatabaseContext.Clients.Update(client);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新客户端登录回调地址配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> ConfigClientScope(List<ClientScopeEditDto> clientScopeCreateDtos, int clientId)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == clientId)
                        .Include(x => x.AllowedScopes)
                        .FirstOrDefaultAsync();

            List<ClientScope> clientScopes = new List<ClientScope>();
            foreach (var item in clientScopeCreateDtos)
            {
                clientScopes.Add(new ClientScope
                {
                    Scope = item.Scope
                });
            }
            client.AllowedScopes = clientScopes;
            try
            {
                _userDatabaseContext.Clients.Update(client);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新客户端API域配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> ConfigClientSecret(List<ClientSecretEditDto> clientSecretCreateDtos, int clientId)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == clientId)
                        .Include(x => x.ClientSecrets)
                        .FirstOrDefaultAsync();


            List<ClientSecret> clientSecrets = new List<ClientSecret>();
            foreach (var item in clientSecretCreateDtos)
            {
                clientSecrets.Add(new ClientSecret
                {
                    Created = DateTime.Now,
                    Description = item.Description,
                    Expiration = item.Expiration,
                    Type = "SharedSecret",
                    Value = item.Value.ToSha256(),
                });
            }
            client.ClientSecrets = clientSecrets;
            try
            {
                _userDatabaseContext.Clients.Update(client);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新客户端秘钥配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> CreateClient(ClientEditDto dto)
        {
            //List<ClientIdPRestriction> clientIdPRestrictions = new List<ClientIdPRestriction>();
            //foreach (var item in clientCreateDto.IdentityProviderRestrictions)
            //{
            //    clientIdPRestrictions.Add(new ClientIdPRestriction
            //    {
            //        Provider = item.Provider
            //    });
            //}

            //List<IdentityServer4.EntityFramework.Entities.ClientClaim> clientClaims = new List<IdentityServer4.EntityFramework.Entities.ClientClaim>();
            //foreach (var item in clientCreateDto.Claims)
            //{
            //    clientClaims.Add(new IdentityServer4.EntityFramework.Entities.ClientClaim
            //    {
            //        Type = item.Type,
            //        Value = item.Value
            //    });
            //}

            List<ClientCorsOrigin> clientCorsOrigins = new List<ClientCorsOrigin>();
            foreach (var item in dto.AllowedCorsOrigins)
            {
                clientCorsOrigins.Add(new ClientCorsOrigin
                {
                    Origin = item.Origin
                });
            }

            //List<ClientProperty> clientProperties = new List<ClientProperty>();
            //foreach (var item in clientCreateDto.Properties)
            //{
            //    clientProperties.Add(new ClientProperty
            //    {
            //        Key = item.Key,
            //        Value = item.Value
            //    });
            //}

            List<ClientScope> clientScopes = new List<ClientScope>();
            foreach (var item in dto.AllowedScopes)
            {
                clientScopes.Add(new ClientScope
                {
                    Scope = item.Scope
                });
            }

            List<ClientSecret> clientSecrets = new List<ClientSecret>();
            foreach (var item in dto.ClientSecrets)
            {
                clientSecrets.Add(new ClientSecret
                {
                    Created = DateTime.Now,
                    Description = item.Description,
                    Expiration = item.Expiration,
                    Type = "SharedSecret",
                    Value = item.Value.ToSha256(),
                });
            }

            List<ClientGrantType> clientGrantTypes = new List<ClientGrantType>();
            foreach (var item in dto.AllowedGrantTypes)
            {
                clientGrantTypes.Add(new ClientGrantType
                {
                    GrantType = item.GrantType
                });
            }

            List<ClientRedirectUri> clientRedirectUris = new List<ClientRedirectUri>();
            foreach (var item in dto.RedirectUris)
            {
                clientRedirectUris.Add(new ClientRedirectUri
                {
                    RedirectUri = item.RedirectUri
                });
            }

            List<ClientPostLogoutRedirectUri> clientPostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>();
            foreach (var item in dto.PostLogoutRedirectUris)
            {
                clientPostLogoutRedirectUris.Add(new ClientPostLogoutRedirectUri
                {
                    PostLogoutRedirectUri = item.PostLogoutRedirectUri
                });
            }
            try
            {
                var client = new IdentityServer4.EntityFramework.Entities.Client
                {
                    Enabled = dto.Enabled,
                    ClientId = dto.ClientId,
                    RequireClientSecret = true,
                    ClientName = dto.ClientName,
                    Description = dto.Description ?? "",
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser=true,
                    AllowOfflineAccess=true,
                    IdentityTokenLifetime=300,
                    AccessTokenLifetime = dto.AccessTokenLifetime ?? 3600,
                    AuthorizationCodeLifetime=300,
                    ConsentLifetime = null,
                    AbsoluteRefreshTokenLifetime= 2592000,
                    SlidingRefreshTokenLifetime= 1296000,
                    RefreshTokenUsage = (int)TokenUsage.OneTimeOnly,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    RefreshTokenExpiration = (int)TokenExpiration.Absolute,
                    AccessTokenType = 0,
                    EnableLocalLogin = true,
                    IncludeJwtId = true,
                    AlwaysSendClientClaims = false,
                    ClientClaimsPrefix =  "client_",
                    PairWiseSubjectSalt = null,
                    Created = DateTime.Now,
                    UserSsoLifetime = null,
                    UserCodeType = null,
                    DeviceCodeLifetime = 300,
                    NonEditable = dto.NonEditable,
                    ClientSecrets = clientSecrets,
                    AllowedGrantTypes = clientGrantTypes,
                    RedirectUris = clientRedirectUris,
                    PostLogoutRedirectUris = clientPostLogoutRedirectUris,
                    AllowedScopes = clientScopes,
                    //IdentityProviderRestrictions = clientIdPRestrictions,
                    AllowedCorsOrigins = clientCorsOrigins,
                    //Properties = clientProperties,
                    //Claims = clientClaims,
                    //RequirePkce = clientCreateDto.RequirePkce ?? true,
                };


                _userDatabaseContext.Clients.Add(client);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "创建客户端成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetById(int id)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == id)
                .Include(x => x.ClientSecrets)
                .Include(x => x.AllowedGrantTypes)
                .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.Claims)
                .Include(x => x.AllowedCorsOrigins)
                .Include(x => x.Properties)
                .FirstOrDefaultAsync();

            if (client == null)
            {
                return new ResultModel(ResultCode.Fail, "没有对应客户端");
            }

            List<ClientSecretDto> clientSecretDtos = new List<ClientSecretDto>();
            foreach (var item in client.ClientSecrets)
            {
                clientSecretDtos.Add(new ClientSecretDto
                {
                    Created = item.Created,
                    Description = item.Description,
                    Expiration = item.Expiration,
                    Type = item.Type,
                    Value = item.Value,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            List<ClientGrantTypeDto> clientGrantTypeDtos = new List<ClientGrantTypeDto>();
            foreach (var item in client.AllowedGrantTypes)
            {
                clientGrantTypeDtos.Add(new ClientGrantTypeDto
                {
                    GrantType = item.GrantType,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            List<ClientRedirectUriDto> clientRedirectUriDtos = new List<ClientRedirectUriDto>();
            foreach (var item in client.RedirectUris)
            {
                clientRedirectUriDtos.Add(new ClientRedirectUriDto
                {
                    RedirectUri = item.RedirectUri,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            List<ClientPostLogoutRedirectUriDto> clientPostLogoutRedirectUriDtos = new List<ClientPostLogoutRedirectUriDto>();
            foreach (var item in client.PostLogoutRedirectUris)
            {
                clientPostLogoutRedirectUriDtos.Add(new ClientPostLogoutRedirectUriDto
                {
                    PostLogoutRedirectUri = item.PostLogoutRedirectUri,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            List<ClientScopeDto> clientScopeDtos = new List<ClientScopeDto>();
            foreach (var item in client.AllowedScopes)
            {
                clientScopeDtos.Add(new ClientScopeDto
                {
                    Scope = item.Scope,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            List<ClientIdPRestrictionDto> clientIdPRestrictionDtos = new List<ClientIdPRestrictionDto>();
            foreach (var item in client.IdentityProviderRestrictions)
            {
                clientIdPRestrictionDtos.Add(new ClientIdPRestrictionDto
                {
                    Provider = item.Provider,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            List<ClientClaimDto> clientClaimDtos = new List<ClientClaimDto>();
            foreach (var item in client.Claims)
            {
                clientClaimDtos.Add(new ClientClaimDto
                {
                    Type = item.Type,
                    Value = item.Value,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            List<ClientCorsOriginDto> clientCorsOriginDtos = new List<ClientCorsOriginDto>();
            foreach (var item in client.AllowedCorsOrigins)
            {
                clientCorsOriginDtos.Add(new ClientCorsOriginDto
                {
                    Origin = item.Origin,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            List<ClientPropertyDto> clientPropertyDtos = new List<ClientPropertyDto>();
            foreach (var item in client.Properties)
            {
                clientPropertyDtos.Add(new ClientPropertyDto
                {
                    Key = item.Key,
                    Value = item.Value,
                    Id = item.Id,
                    ClientId = item.ClientId
                });
            }

            var clientDto = new ClientDto
            {
                Id = client.Id,
                Enabled = client.Enabled,
                ClientId = client.ClientId,
                ProtocolType = client.ProtocolType,
                RequireClientSecret = client.RequireClientSecret,
                ClientName = client.ClientName,
                Description = client.Description,
                ClientUri = client.ClientUri,
                LogoUri = client.LogoUri,
                RequireConsent = client.RequireConsent,
                AllowRememberConsent = client.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = client.AlwaysIncludeUserClaimsInIdToken,
                AllowPlainTextPkce = client.AllowPlainTextPkce,
                RequireRequestObject = client.RequireRequestObject,
                AllowAccessTokensViaBrowser = client.AllowAccessTokensViaBrowser,
                FrontChannelLogoutUri = client.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = client.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = client.BackChannelLogoutUri,
                BackChannelLogoutSessionRequired = client.BackChannelLogoutSessionRequired,
                AllowOfflineAccess = client.AllowOfflineAccess,
                IdentityTokenLifetime = client.IdentityTokenLifetime,
                AllowedIdentityTokenSigningAlgorithms = client.AllowedIdentityTokenSigningAlgorithms,
                AccessTokenLifetime = client.AccessTokenLifetime,
                AuthorizationCodeLifetime = client.AuthorizationCodeLifetime,
                AbsoluteRefreshTokenLifetime = client.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = client.SlidingRefreshTokenLifetime,
                RefreshTokenUsage = client.RefreshTokenUsage,
                UpdateAccessTokenClaimsOnRefresh = client.UpdateAccessTokenClaimsOnRefresh,
                RefreshTokenExpiration = client.RefreshTokenExpiration,
                AccessTokenType = 0,
                EnableLocalLogin = client.EnableLocalLogin,
                IncludeJwtId = client.IncludeJwtId,
                AlwaysSendClientClaims = client.AlwaysSendClientClaims,
                ClientClaimsPrefix = client.ClientClaimsPrefix,
                PairWiseSubjectSalt = client.PairWiseSubjectSalt,
                Created = client.Created,
                Updated = client.Updated,
                LastAccessed = client.LastAccessed,
                RequirePkce=client.RequirePkce,
                UserSsoLifetime = client.UserSsoLifetime,
                UserCodeType = client.UserCodeType,
                DeviceCodeLifetime = client.DeviceCodeLifetime,
                NonEditable = client.NonEditable,
                ClientSecrets = clientSecretDtos,
                AllowedGrantTypes = clientGrantTypeDtos,
                RedirectUris = clientRedirectUriDtos,
                PostLogoutRedirectUris = clientPostLogoutRedirectUriDtos,
                AllowedScopes = clientScopeDtos,
                IdentityProviderRestrictions = clientIdPRestrictionDtos,
                AllowedCorsOrigins = clientCorsOriginDtos,
                Properties = clientPropertyDtos,
                Claims=clientClaimDtos
            };

            return new ResultModel(ResultCode.Success, clientDto);
        }

        public async Task<ResultModel> GetList(ClientQueryDto clientQueryDto)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var query = _userDatabaseContext.Clients.Where(x => 1 == 1);
                    if (!string.IsNullOrWhiteSpace(clientQueryDto.ClientName))
                    {
                        query = query.Where(x => x.ClientName.Contains(clientQueryDto.ClientName));
                    }
                    var list = query.OrderBy(x => x.Id).Select(x => new ClientDto
                    {
                        Id = x.Id,
                        Enabled = x.Enabled,
                        ClientId = x.ClientId,
                        RequireClientSecret = x.RequireClientSecret,
                        ClientName = x.ClientName,
                        AccessTokenLifetime = x.AccessTokenLifetime,
                        Created = x.Created,
                        Updated = x.Updated
                    });
                    var page = PagedList<ClientDto>.ToPagedList(list, clientQueryDto.CurrentPage, clientQueryDto.PageSize);
                    return new ResultModel(ResultCode.Success, page);
                }
                catch (Exception ex)
                {
                    return new ResultModel(ResultCode.Fail, ex.Message);
                }
            });
        }

        public async Task<ResultModel> UpdateClient(ClientEditDto clientUpdateDto)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == clientUpdateDto.Id)
                //.Include(x => x.ClientSecrets)
                //.Include(x => x.AllowedGrantTypes)
                //.Include(x => x.RedirectUris)
                //.Include(x => x.PostLogoutRedirectUris)
                //.Include(x => x.AllowedScopes)
                //.Include(x => x.IdentityProviderRestrictions)
                //.Include(x => x.Claims)
                //.Include(x => x.AllowedCorsOrigins)
                //.Include(x => x.Properties)
                .FirstOrDefaultAsync();

            client.Enabled = clientUpdateDto.Enabled;
            client.ClientId = clientUpdateDto.ClientId;
            client.ClientName = clientUpdateDto.ClientName;
            client.Description = clientUpdateDto.Description;
            client.AccessTokenLifetime = clientUpdateDto.AccessTokenLifetime.Value;
            client.Updated = DateTime.Now;
            client.NonEditable = clientUpdateDto.NonEditable;

            //List<ClientIdPRestriction> clientIdPRestrictions = new List<ClientIdPRestriction>();
            //foreach (var item in clientUpdateDto.IdentityProviderRestrictions)
            //{
            //    clientIdPRestrictions.Add(new ClientIdPRestriction
            //    {
            //        Provider = item.Provider
            //    });
            //}

            //List<IdentityServer4.EntityFramework.Entities.ClientClaim> clientClaims = new List<IdentityServer4.EntityFramework.Entities.ClientClaim>();
            //foreach (var item in clientUpdateDto.Claims)
            //{
            //    clientClaims.Add(new IdentityServer4.EntityFramework.Entities.ClientClaim
            //    {
            //        Type = item.Type,
            //        Value = item.Value
            //    });
            //}

            //List<ClientCorsOrigin> clientCorsOrigins = new List<ClientCorsOrigin>();
            //foreach (var item in clientUpdateDto.AllowedCorsOrigins)
            //{
            //    clientCorsOrigins.Add(new ClientCorsOrigin
            //    {
            //        Origin = item.Origin
            //    });
            //}

            //List<ClientProperty> clientProperties = new List<ClientProperty>();
            //foreach (var item in clientUpdateDto.Properties)
            //{
            //    clientProperties.Add(new ClientProperty
            //    {
            //        Key = item.Key,
            //        Value = item.Value
            //    });
            //}

            //List<ClientScope> clientScopes = new List<ClientScope>();
            //foreach (var item in clientUpdateDto.AllowedScopes)
            //{
            //    clientScopes.Add(new ClientScope
            //    {
            //        Scope = item.Scope
            //    });
            //}

            //List<ClientSecret> clientSecrets = new List<ClientSecret>();
            //foreach (var item in clientUpdateDto.ClientSecrets)
            //{
            //    clientSecrets.Add(new ClientSecret
            //    {
            //        Created = DateTime.Now,
            //        Description = item.Description,
            //        Expiration = item.Expiration,
            //        Type = "SharedSecret",
            //        Value = item.Value.ToSha256(),
            //    });
            //}

            //List<ClientGrantType> clientGrantTypes = new List<ClientGrantType>();
            //foreach (var item in clientUpdateDto.AllowedGrantTypes)
            //{
            //    clientGrantTypes.Add(new ClientGrantType
            //    {
            //        GrantType = item.GrantType
            //    });
            //}

            //List<ClientRedirectUri> clientRedirectUris = new List<ClientRedirectUri>();
            //foreach (var item in clientUpdateDto.RedirectUris)
            //{
            //    clientRedirectUris.Add(new ClientRedirectUri
            //    {
            //        RedirectUri = item.RedirectUri
            //    });
            //}

            //List<ClientPostLogoutRedirectUri> clientPostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>();
            //foreach (var item in clientUpdateDto.PostLogoutRedirectUris)
            //{
            //    clientPostLogoutRedirectUris.Add(new ClientPostLogoutRedirectUri
            //    {
            //        PostLogoutRedirectUri = item.PostLogoutRedirectUri
            //    });
            //}


            //client.ClientSecrets = clientSecrets;
            //client.AllowedGrantTypes = clientGrantTypes;
            //client.RedirectUris = clientRedirectUris;
            //client.PostLogoutRedirectUris = clientPostLogoutRedirectUris;
            //client.AllowedScopes = clientScopes;
            //client.IdentityProviderRestrictions = clientIdPRestrictions;
            //client.AllowedCorsOrigins = clientCorsOrigins;
            //client.Properties = clientProperties;
            //client.Claims = clientClaims;

            try
            {
                _userDatabaseContext.Clients.Update(client);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新客户端成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }
    }
}
