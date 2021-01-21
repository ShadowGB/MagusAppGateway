using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientQueryDto: QueryModelBase
    {
        public bool Enabled { get; set; } = true;
        public string ClientId { get; set; }
        public bool RequireClientSecret { get; set; } = true;
        public string ClientName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool NonEditable { get; set; }
    }
}
