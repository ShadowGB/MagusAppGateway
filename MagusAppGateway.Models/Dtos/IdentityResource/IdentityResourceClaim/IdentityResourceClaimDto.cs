using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.Models.Dtos
{
    public class IdentityResourceClaimDto
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int IdentityResourceId { get; set; }
    }
}
