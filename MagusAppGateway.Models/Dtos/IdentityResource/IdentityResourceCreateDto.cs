using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class IdentityResourceCreateDto
    {
        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public bool Emphasize { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }

        public List<IdentityResourceClaimCreateDto> UserClaims { get; set; }

        public List<IdentityResourcePropertyCreateDto> Properties { get; set; }

        public bool NonEditable { get; set; }
    }
}
