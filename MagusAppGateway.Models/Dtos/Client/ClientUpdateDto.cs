using System;
using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientUpdateDto
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string ClientId { get; set; }
        //public string ProtocolType { get; set; }
        public List<ClientSecretUpdateDto> ClientSecrets { get; set; }
        public bool RequireClientSecret { get; set; } = true;
        public string ClientName { get; set; }
        public string Description { get; set; }
        //public string ClientUri { get; set; }
        //public string LogoUri { get; set; }
        //public bool RequireConsent { get; set; }
        //public bool AllowRememberConsent { get; set; }
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public List<ClientGrantTypeUpdateDto> AllowedGrantTypes { get; set; }
        //public bool RequirePkce { get; set; }
        //public bool AllowPlainTextPkce { get; set; }
        //public bool RequireRequestObject { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public List<ClientRedirectUriUpdateDto> RedirectUris { get; set; }
        public List<ClientPostLogoutRedirectUriUpdateDto> PostLogoutRedirectUris { get; set; }
        //public string FrontChannelLogoutUri { get; set; }
        //public bool FrontChannelLogoutSessionRequired { get; set; }
        //public string BackChannelLogoutUri { get; set; }
        //public bool BackChannelLogoutSessionRequired { get; set; }
        public bool AllowOfflineAccess { get; set; }
        public List<ClientScopeUpdateDto> AllowedScopes { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public string AllowedIdentityTokenSigningAlgorithms { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int AuthorizationCodeLifetime { get; set; }
        public int? ConsentLifetime { get; set; } = null;
        public int AbsoluteRefreshTokenLifetime { get; set; }
        public int SlidingRefreshTokenLifetime { get; set; }
        public int RefreshTokenUsage { get; set; }
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        public int RefreshTokenExpiration { get; set; }
        //public int AccessTokenType { get; set; }
        public bool EnableLocalLogin { get; set; }
        //public List<ClientIdPRestrictionUpdateDto> IdentityProviderRestrictions { get; set; }
        public bool IncludeJwtId { get; set; }
        //public List<ClientClaimUpdateDto> Claims { get; set; }
        public bool AlwaysSendClientClaims { get; set; }
        public string ClientClaimsPrefix { get; set; }
        public string PairWiseSubjectSalt { get; set; }
        public List<ClientCorsOriginUpdateDto> AllowedCorsOrigins { get; set; }
        //public List<ClientPropertyUpdateDto> Properties { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public int? UserSsoLifetime { get; set; }
        public string UserCodeType { get; set; }
        public int DeviceCodeLifetime { get; set; }
        public bool NonEditable { get; set; }
    }
}
