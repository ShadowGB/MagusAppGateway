using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class UserRoleDto
    {
        [Display(Name = "编号")]
        public string RoleId { get; set; }

        [Display(Name = "角色名称")]
        public string RoleName { get; set; }

        [Display(Name = "是否有权限")]
        public bool? IsHaveRole { get; set; }
    }
}
