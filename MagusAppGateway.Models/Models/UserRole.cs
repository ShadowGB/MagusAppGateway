using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.Models
{
    public class UserRole:BaseModel
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public Users Users { get; set; }

        public Roles Roles { get; set; }
    }
}
