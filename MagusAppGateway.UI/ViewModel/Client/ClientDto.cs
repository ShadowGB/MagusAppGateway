using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientDto: QueryModelBase
    {
        public ClientDto()
        {
            ClientSecrets = new List<ClientSecretDto>();
            AllowedGrantTypes = new List<ClientGrantTypeDto>();
            RedirectUris = new List<ClientRedirectUriDto>();
            PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUriDto>();
            AllowedScopes = new List<ClientScopeDto>();
            IdentityProviderRestrictions = new List<ClientIdPRestrictionDto>();
            Claims = new List<ClientClaimDto>();
            AllowedCorsOrigins = new List<ClientCorsOriginDto>();
            Properties = new List<ClientPropertyDto>();
        }

        [Display(Name = "编号")]
        public int Id { get; set; }

        [Display(Name ="是否启用")]
        public bool Enabled { get; set; } = true;

        [Display(Name ="客户端编号")]
        public string ClientId { get; set; }
        public string ProtocolType { get; set; } = "oidc";
        public List<ClientSecretDto> ClientSecrets { get; set; }

        [Display(Name ="是否需要客户端秘钥")]
        public bool RequireClientSecret { get; set; } = true;

        [Display(Name ="客户端名称")]
        public string ClientName { get; set; }

        [Display(Name ="描述")]
        public string Description { get; set; }

        public string ClientUri { get; set; }

        public string LogoUri { get; set; }

        public bool RequireConsent { get; set; } = false;

        public bool AllowRememberConsent { get; set; } = true;

        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        public List<ClientGrantTypeDto> AllowedGrantTypes { get; set; }

        public bool RequirePkce { get; set; } = true;

        public bool AllowPlainTextPkce { get; set; }

        public bool RequireRequestObject { get; set; }

        public bool AllowAccessTokensViaBrowser { get; set; }

        public List<ClientRedirectUriDto> RedirectUris { get; set; }

        public List<ClientPostLogoutRedirectUriDto> PostLogoutRedirectUris { get; set; }

        public string FrontChannelLogoutUri { get; set; }

        public bool FrontChannelLogoutSessionRequired { get; set; } = true;

        public string BackChannelLogoutUri { get; set; }

        public bool BackChannelLogoutSessionRequired { get; set; } = true;

        public bool AllowOfflineAccess { get; set; }

        public List<ClientScopeDto> AllowedScopes { get; set; }

        public int IdentityTokenLifetime { get; set; } = 300;

        public string AllowedIdentityTokenSigningAlgorithms { get; set; }

        [Display(Name ="Tokan生命周期(秒)")]
        public int AccessTokenLifetime { get; set; } = 3600;

        public int AuthorizationCodeLifetime { get; set; } = 300;

        public int? ConsentLifetime { get; set; } = null;

        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;

        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;

        public int RefreshTokenUsage { get; set; } = (int)TokenUsage.OneTimeOnly;

        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        public int RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;

        public int AccessTokenType { get; set; } = (int)0; // AccessTokenType.Jwt;

        public bool EnableLocalLogin { get; set; } = true;

        public List<ClientIdPRestrictionDto> IdentityProviderRestrictions { get; set; }

        public bool IncludeJwtId { get; set; }

        public List<ClientClaimDto> Claims { get; set; }

        public bool AlwaysSendClientClaims { get; set; }

        public string ClientClaimsPrefix { get; set; } = "client_";

        public string PairWiseSubjectSalt { get; set; }

        public List<ClientCorsOriginDto> AllowedCorsOrigins { get; set; }

        public List<ClientPropertyDto> Properties { get; set; }

        [Display(Name ="创建时间")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Display(Name ="更新时间")]
        public DateTime? Updated { get; set; }

        public DateTime? LastAccessed { get; set; }

        public int? UserSsoLifetime { get; set; }

        public string UserCodeType { get; set; }

        public int DeviceCodeLifetime { get; set; } = 300;

        public bool NonEditable { get; set; } = false;
    }
}
