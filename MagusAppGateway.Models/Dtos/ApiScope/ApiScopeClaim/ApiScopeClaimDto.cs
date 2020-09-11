using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.Models.Dtos
{
    public class ApiScopeClaimDto
    {
        public int ScopeId { get; set; }

        public int Id { get; set; }

        public string Type { get; set; }
    }
}
