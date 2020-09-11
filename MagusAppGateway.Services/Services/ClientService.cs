using System;
using System.Linq;
using System.Threading.Tasks;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Services.Result;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using IdentityServer4.Models;
using MagusAppGateway.Contexts;
using MagusAppGateway.Models.Dtos;
using IdentityModel;

namespace MagusAppGateway.Services.Services
{
    public class ClientService:IClientService
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public ClientService(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        public async Task<ResultModel> CreateClient(ClientCreateDto clientCreateDto)
        {
            List<ClientIdPRestriction> clientIdPRestrictions = new List<ClientIdPRestriction>();
            foreach (var item in clientCreateDto.IdentityProviderRestrictions)
            {
                clientIdPRestrictions.Add(new ClientIdPRestriction
                {
                    Provider = item.Provider
                });
            }

            List<IdentityServer4.EntityFramework.Entities.ClientClaim> clientClaims = new List<IdentityServer4.EntityFramework.Entities.ClientClaim>();
            foreach (var item in clientCreateDto.Claims)
            {
                clientClaims.Add(new IdentityServer4.EntityFramework.Entities.ClientClaim
                {
                    Type = item.Type,
                    Value = item.Value
                });
            }

            List<ClientCorsOrigin> clientCorsOrigins = new List<ClientCorsOrigin>();
            foreach (var item in clientCreateDto.AllowedCorsOrigins)
            {
                clientCorsOrigins.Add(new ClientCorsOrigin
                {
                    Origin = item.Origin
                });
            }

            List<ClientProperty> clientProperties = new List<ClientProperty>();
            foreach (var item in clientCreateDto.Properties)
            {
                clientProperties.Add(new ClientProperty
                {
                    Key = item.Key,
                    Value = item.Value
                });
            }

            List<ClientScope> clientScopes = new List<ClientScope>();
            foreach (var item in clientCreateDto.AllowedScopes)
            {
                clientScopes.Add(new ClientScope
                {
                    Scope = item.Scope
                });
            }

            List<ClientSecret> clientSecrets = new List<ClientSecret>();
            foreach (var item in clientCreateDto.ClientSecrets)
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
            foreach (var item in clientCreateDto.AllowedGrantTypes)
            {
                clientGrantTypes.Add(new ClientGrantType
                {
                    GrantType = item.GrantType
                });
            }

            List<ClientRedirectUri> clientRedirectUris = new List<ClientRedirectUri>();
            foreach (var item in clientCreateDto.RedirectUris)
            {
                clientRedirectUris.Add(new ClientRedirectUri
                {
                    RedirectUri = item.RedirectUri
                });
            }

            List<ClientPostLogoutRedirectUri> clientPostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>();
            foreach (var item in clientCreateDto.PostLogoutRedirectUris)
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
                    Enabled = clientCreateDto.Enabled,
                    ClientId = clientCreateDto.ClientId,
                    ProtocolType = clientCreateDto.ProtocolType ?? "oidc",
                    RequireClientSecret = clientCreateDto.RequireClientSecret ?? true,
                    ClientName = clientCreateDto.ClientName,
                    Description = clientCreateDto.Description??"",
                    ClientUri = clientCreateDto.ClientUri??"",
                    LogoUri = clientCreateDto.LogoUri ?? "",
                    RequireConsent = clientCreateDto.RequireConsent ?? false,
                    AllowRememberConsent = clientCreateDto.AllowRememberConsent ?? true,
                    AlwaysIncludeUserClaimsInIdToken = clientCreateDto.AlwaysIncludeUserClaimsInIdToken,
                    AllowPlainTextPkce = clientCreateDto.AllowPlainTextPkce,
                    RequireRequestObject = clientCreateDto.RequireRequestObject,
                    AllowAccessTokensViaBrowser = clientCreateDto.AllowAccessTokensViaBrowser,
                    FrontChannelLogoutUri = clientCreateDto.FrontChannelLogoutUri,
                    FrontChannelLogoutSessionRequired = clientCreateDto.FrontChannelLogoutSessionRequired ?? true,
                    BackChannelLogoutUri = clientCreateDto.BackChannelLogoutUri,
                    BackChannelLogoutSessionRequired = clientCreateDto.BackChannelLogoutSessionRequired ?? true,
                    AllowOfflineAccess = clientCreateDto.AllowOfflineAccess,
                    IdentityTokenLifetime = clientCreateDto.IdentityTokenLifetime ?? 300,
                    AllowedIdentityTokenSigningAlgorithms = clientCreateDto.AllowedIdentityTokenSigningAlgorithms,
                    AccessTokenLifetime = clientCreateDto.AccessTokenLifetime ?? 3600,
                    AuthorizationCodeLifetime = clientCreateDto.AuthorizationCodeLifetime ?? 300,
                    ConsentLifetime = null,
                    AbsoluteRefreshTokenLifetime = clientCreateDto.AbsoluteRefreshTokenLifetime ?? 2592000,
                    SlidingRefreshTokenLifetime = clientCreateDto.SlidingRefreshTokenLifetime ?? 1296000,
                    RefreshTokenUsage = clientCreateDto.RefreshTokenUsage ?? (int)TokenUsage.OneTimeOnly,
                    UpdateAccessTokenClaimsOnRefresh = clientCreateDto.UpdateAccessTokenClaimsOnRefresh,
                    RefreshTokenExpiration = clientCreateDto.RefreshTokenExpiration ?? (int)TokenExpiration.Absolute,
                    AccessTokenType = 0,
                    EnableLocalLogin = clientCreateDto.EnableLocalLogin ?? true,
                    IncludeJwtId = clientCreateDto.IncludeJwtId,
                    AlwaysSendClientClaims = clientCreateDto.AlwaysSendClientClaims,
                    ClientClaimsPrefix = clientCreateDto.ClientClaimsPrefix ?? "client_",
                    PairWiseSubjectSalt = clientCreateDto.PairWiseSubjectSalt,
                    Created = DateTime.Now,
                    UserSsoLifetime = clientCreateDto.UserSsoLifetime,
                    UserCodeType = clientCreateDto.UserCodeType,
                    DeviceCodeLifetime = clientCreateDto.DeviceCodeLifetime ?? 300,
                    NonEditable = clientCreateDto.NonEditable,
                    ClientSecrets = clientSecrets,
                    AllowedGrantTypes = clientGrantTypes,
                    RedirectUris = clientRedirectUris,
                    PostLogoutRedirectUris = clientPostLogoutRedirectUris,
                    AllowedScopes = clientScopes,
                    IdentityProviderRestrictions = clientIdPRestrictions,
                    AllowedCorsOrigins = clientCorsOrigins,
                    Properties = clientProperties,
                    Claims = clientClaims,
                    RequirePkce = clientCreateDto.RequirePkce ?? true,
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
            try
            {
                var query = _userDatabaseContext.Clients.Where(x => 1 == 1);
                if (!string.IsNullOrWhiteSpace(clientQueryDto.ClientName))
                {
                    query = query.Where(x => x.ClientName.Contains(clientQueryDto.ClientName));
                }
                var list = await query.ToListAsync();
                return new ResultModel(ResultCode.Success, list);
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> UpdateClient(ClientUpdateDto clientUpdateDto)
        {
            var client = await _userDatabaseContext.Clients.Where(x => x.Id == clientUpdateDto.Id)
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

            client.Enabled = clientUpdateDto.Enabled;
            client.ClientId = clientUpdateDto.ClientId;
            client.ProtocolType = clientUpdateDto.ProtocolType;
            client.RequireClientSecret = clientUpdateDto.RequireClientSecret;
            client.ClientName = clientUpdateDto.ClientName;
            client.Description = clientUpdateDto.Description;
            client.ClientUri = clientUpdateDto.ClientUri;
            client.LogoUri = clientUpdateDto.LogoUri;
            client.RequireConsent = clientUpdateDto.RequireConsent;
            client.AllowRememberConsent = clientUpdateDto.AllowRememberConsent;
            client.AlwaysIncludeUserClaimsInIdToken = clientUpdateDto.AlwaysIncludeUserClaimsInIdToken;
            client.AllowPlainTextPkce = clientUpdateDto.AllowPlainTextPkce;
            client.RequireRequestObject = clientUpdateDto.RequireRequestObject;
            client.AllowAccessTokensViaBrowser = clientUpdateDto.AllowAccessTokensViaBrowser;
            client.FrontChannelLogoutUri = clientUpdateDto.FrontChannelLogoutUri;
            client.FrontChannelLogoutSessionRequired = clientUpdateDto.FrontChannelLogoutSessionRequired;
            client.BackChannelLogoutUri = clientUpdateDto.BackChannelLogoutUri;
            client.BackChannelLogoutSessionRequired = clientUpdateDto.BackChannelLogoutSessionRequired;
            client.AllowOfflineAccess = clientUpdateDto.AllowOfflineAccess;
            client.IdentityTokenLifetime = clientUpdateDto.IdentityTokenLifetime;
            client.AllowedIdentityTokenSigningAlgorithms = clientUpdateDto.AllowedIdentityTokenSigningAlgorithms;
            client.AccessTokenLifetime = clientUpdateDto.AccessTokenLifetime;
            client.AuthorizationCodeLifetime = clientUpdateDto.AuthorizationCodeLifetime;
            client.AbsoluteRefreshTokenLifetime = clientUpdateDto.AbsoluteRefreshTokenLifetime;
            client.SlidingRefreshTokenLifetime = clientUpdateDto.SlidingRefreshTokenLifetime;
            client.RefreshTokenUsage = clientUpdateDto.RefreshTokenUsage;
            client.UpdateAccessTokenClaimsOnRefresh = clientUpdateDto.UpdateAccessTokenClaimsOnRefresh;
            client.RefreshTokenExpiration = clientUpdateDto.RefreshTokenExpiration;
            client.AccessTokenType = 0;
            client.EnableLocalLogin = clientUpdateDto.EnableLocalLogin;
            client.IncludeJwtId = clientUpdateDto.IncludeJwtId;
            client.AlwaysSendClientClaims = clientUpdateDto.AlwaysSendClientClaims;
            client.ClientClaimsPrefix = clientUpdateDto.ClientClaimsPrefix;
            client.PairWiseSubjectSalt = clientUpdateDto.PairWiseSubjectSalt;
            client.Updated = DateTime.Now;
            client.LastAccessed = clientUpdateDto.LastAccessed;
            client.RequirePkce = clientUpdateDto.RequirePkce;
            client.UserSsoLifetime = clientUpdateDto.UserSsoLifetime;
            client.UserCodeType = clientUpdateDto.UserCodeType;
            client.DeviceCodeLifetime = clientUpdateDto.DeviceCodeLifetime;
            client.NonEditable = clientUpdateDto.NonEditable;

            List<ClientIdPRestriction> clientIdPRestrictions = new List<ClientIdPRestriction>();
            foreach (var item in clientUpdateDto.IdentityProviderRestrictions)
            {
                clientIdPRestrictions.Add(new ClientIdPRestriction
                {
                    Provider = item.Provider
                });
            }

            List<IdentityServer4.EntityFramework.Entities.ClientClaim> clientClaims = new List<IdentityServer4.EntityFramework.Entities.ClientClaim>();
            foreach (var item in clientUpdateDto.Claims)
            {
                clientClaims.Add(new IdentityServer4.EntityFramework.Entities.ClientClaim
                {
                    Type = item.Type,
                    Value = item.Value
                });
            }

            List<ClientCorsOrigin> clientCorsOrigins = new List<ClientCorsOrigin>();
            foreach (var item in clientUpdateDto.AllowedCorsOrigins)
            {
                clientCorsOrigins.Add(new ClientCorsOrigin
                {
                    Origin = item.Origin
                });
            }

            List<ClientProperty> clientProperties = new List<ClientProperty>();
            foreach (var item in clientUpdateDto.Properties)
            {
                clientProperties.Add(new ClientProperty
                {
                    Key = item.Key,
                    Value = item.Value
                });
            }

            List<ClientScope> clientScopes = new List<ClientScope>();
            foreach (var item in clientUpdateDto.AllowedScopes)
            {
                clientScopes.Add(new ClientScope
                {
                    Scope = item.Scope
                });
            }

            List<ClientSecret> clientSecrets = new List<ClientSecret>();
            foreach (var item in clientUpdateDto.ClientSecrets)
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
            foreach (var item in clientUpdateDto.AllowedGrantTypes)
            {
                clientGrantTypes.Add(new ClientGrantType
                {
                    GrantType = item.GrantType
                });
            }

            List<ClientRedirectUri> clientRedirectUris = new List<ClientRedirectUri>();
            foreach (var item in clientUpdateDto.RedirectUris)
            {
                clientRedirectUris.Add(new ClientRedirectUri
                {
                    RedirectUri = item.RedirectUri
                });
            }

            List<ClientPostLogoutRedirectUri> clientPostLogoutRedirectUris = new List<ClientPostLogoutRedirectUri>();
            foreach (var item in clientUpdateDto.PostLogoutRedirectUris)
            {
                clientPostLogoutRedirectUris.Add(new ClientPostLogoutRedirectUri
                {
                    PostLogoutRedirectUri = item.PostLogoutRedirectUri
                });
            }


            client.ClientSecrets = clientSecrets;
            client.AllowedGrantTypes = clientGrantTypes;
            client.RedirectUris = clientRedirectUris;
            client.PostLogoutRedirectUris = clientPostLogoutRedirectUris;
            client.AllowedScopes = clientScopes;
            client.IdentityProviderRestrictions = clientIdPRestrictions;
            client.AllowedCorsOrigins = clientCorsOrigins;
            client.Properties = clientProperties;
            client.Claims = clientClaims;

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
