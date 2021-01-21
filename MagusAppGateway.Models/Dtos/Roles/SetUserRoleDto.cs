using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class SetUserRoleDto
    {
        public SetUserRoleDto()
        {
            RoleIds = new List<Guid>();
        }

        public Guid UserId { get; set; }

        public List<Guid> RoleIds { get; set; }
    }
}
