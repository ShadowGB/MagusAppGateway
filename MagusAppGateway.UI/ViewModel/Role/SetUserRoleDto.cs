using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.ViewModel
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
