using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.Models
{
    public class Roles : BaseModel
    {
        public string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
