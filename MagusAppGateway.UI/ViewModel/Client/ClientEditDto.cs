using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientEditDto
    {
        public ClientEditDto()
        {
            ClientSecrets = new List<ClientSecretEditDto>();
            AllowedGrantTypes = new List<ClientGrantTypeEditDto>();
            RedirectUris = new List<ClientRedirectUriEditDto>();
            PostLogoutRedirectUris = new List<ClientPostLogoutRedirectUriEditDto>();
            AllowedScopes = new List<ClientScopeEditDto>();
            IdentityProviderRestrictions = new List<ClientIdPRestrictionEditDto>();
            Claims = new List<ClientClaimEditDto>();
            AllowedCorsOrigins = new List<ClientCorsOriginEditDto>();
            Properties = new List<ClientPropertyEditDto>();
        }

        public int? Id { get; set; }

        public bool Enabled { get; set; }

        public string ClientId { get; set; }

        public List<ClientSecretEditDto> ClientSecrets { get; set; }

        public string ClientName { get; set; }

        public string Description { get; set; }

        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        public List<ClientGrantTypeEditDto> AllowedGrantTypes { get; set; }

        public List<ClientRedirectUriEditDto> RedirectUris { get; set; }

        public List<ClientPostLogoutRedirectUriEditDto> PostLogoutRedirectUris { get; set; }

        public List<ClientScopeEditDto> AllowedScopes { get; set; }

        public int? AccessTokenLifetime { get; set; }

        public List<ClientIdPRestrictionEditDto> IdentityProviderRestrictions { get; set; }

        public List<ClientClaimEditDto> Claims { get; set; }

        public List<ClientCorsOriginEditDto> AllowedCorsOrigins { get; set; }

        public List<ClientPropertyEditDto> Properties { get; set; }

        public bool NonEditable { get; set; }
    }
}
