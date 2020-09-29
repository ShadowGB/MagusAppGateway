using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientCreateDto
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 客户端编号
        /// </summary>
        public string ClientId { get; set; }

        //public string ProtocolType { get; set; } = "oidc";

        /// <summary>
        /// 客户端秘钥
        /// </summary>
        public List<ClientSecretCreateDto> ClientSecrets { get; set; }

        //public bool? RequireClientSecret { get; set; } = true;

        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 秒速
        /// </summary>
        public string Description { get; set; }

        //public string ClientUri { get; set; }

        //public string LogoUri { get; set; }

        //public bool? RequireConsent { get; set; } = false;

        //public bool? AllowRememberConsent { get; set; } = true;

        //public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        /// <summary>
        /// 授权类型
        /// </summary>
        public List<ClientGrantTypeCreateDto> AllowedGrantTypes { get; set; }

        //public bool? RequirePkce { get; set; } = true;

        //public bool AllowPlainTextPkce { get; set; }

        //public bool RequireRequestObject { get; set; }

        //public bool AllowAccessTokensViaBrowser { get; set; }

        /// <summary>
        /// 登录回调地址
        /// </summary>
        public List<ClientRedirectUriCreateDto> RedirectUris { get; set; }

        /// <summary>
        /// 登出回调地址
        /// </summary>
        public List<ClientPostLogoutRedirectUriCreateDto> PostLogoutRedirectUris { get; set; }

        //public string FrontChannelLogoutUri { get; set; }

        //public bool? FrontChannelLogoutSessionRequired { get; set; } = true;

        //public string BackChannelLogoutUri { get; set; }

        //public bool? BackChannelLogoutSessionRequired { get; set; } = true;

        //public bool AllowOfflineAccess { get; set; }

        /// <summary>
        /// 允许访问的API域
        /// </summary>
        public List<ClientScopeCreateDto> AllowedScopes { get; set; }

       //public int? IdentityTokenLifetime { get; set; } = 300;

        //public string AllowedIdentityTokenSigningAlgorithms { get; set; }

        /// <summary>
        /// Token过期时间（秒）
        /// </summary>
        public int? AccessTokenLifetime { get; set; } = 3600;

        //public int? AuthorizationCodeLifetime { get; set; } = 300;

        //public int? ConsentLifetime { get; set; } = null;

        //public int? AbsoluteRefreshTokenLifetime { get; set; } = 2592000;

        //public int? SlidingRefreshTokenLifetime { get; set; } = 1296000;

        //public int? RefreshTokenUsage { get; set; } = (int)TokenUsage.OneTimeOnly;

        //public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        //public int? RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;

        //public int? AccessTokenType { get; set; } = (int)0; // AccessTokenType.Jwt;

        //public bool? EnableLocalLogin { get; set; } = true;

        //public List<ClientIdPRestrictionCreateDto> IdentityProviderRestrictions { get; set; }

        //public bool IncludeJwtId { get; set; }

        //public List<ClientClaimCreateDto> Claims { get; set; }

        //public bool AlwaysSendClientClaims { get; set; }

        //public string ClientClaimsPrefix { get; set; } = "client_";

        //public string PairWiseSubjectSalt { get; set; }

        /// <summary>
        /// 允许跨域访问地址
        /// </summary>
        public List<ClientCorsOriginCreateDto> AllowedCorsOrigins { get; set; }

        //public List<ClientPropertyCreateDto> Properties { get; set; }

        //public int? UserSsoLifetime { get; set; }

        //public string UserCodeType { get; set; }

        //public int? DeviceCodeLifetime { get; set; } = 300;

        /// <summary>
        /// 是否不可编辑
        /// </summary>
        public bool NonEditable { get; set; }
    }
}
