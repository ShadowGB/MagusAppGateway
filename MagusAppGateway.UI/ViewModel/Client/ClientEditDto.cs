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

        [Display(Name ="编号")]
        public int? Id { get; set; }

        [Display(Name = "是否启用")]
        public bool Enabled { get; set; }

        [Display(Name = "客户端ID")]
        public string ClientId { get; set; }

        [Display(Name = "是否需要秘钥")]
        public bool RequireClientSecret { get; set; }

        public List<ClientSecretEditDto> ClientSecrets { get; set; }

        [Display(Name = "客户端名称")]
        public string ClientName { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        public List<ClientGrantTypeEditDto> AllowedGrantTypes { get; set; }

        public List<ClientRedirectUriEditDto> RedirectUris { get; set; }

        public List<ClientPostLogoutRedirectUriEditDto> PostLogoutRedirectUris { get; set; }

        public List<ClientScopeEditDto> AllowedScopes { get; set; }

        [Display(Name = "Token过期时间(秒)")]
        public int? AccessTokenLifetime { get; set; } = 3600;

        public List<ClientIdPRestrictionEditDto> IdentityProviderRestrictions { get; set; }

        public List<ClientClaimEditDto> Claims { get; set; }

        public List<ClientCorsOriginEditDto> AllowedCorsOrigins { get; set; }

        public List<ClientPropertyEditDto> Properties { get; set; }

        public bool NonEditable { get; set; }
    }
}
