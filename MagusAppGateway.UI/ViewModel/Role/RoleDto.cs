using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.ViewModel
{
    public class RoleDto : QueryModelBase
    {
        public string Id { get; set; }

        public string RoleName { get; set; }
    }
}
