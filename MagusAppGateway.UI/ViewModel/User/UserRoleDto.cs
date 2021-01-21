using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.ViewModel
{
    public class UserRoleDto:QueryModelBase
    {
        [Display(Name = "角色编号")]
        public string RoleId { get; set; }

        [Display(Name = "用户编号")]
        public string UserId { get; set; }

        [Display(Name = "角色名称")]
        public string RoleName { get; set; }

        [Display(Name = "是否有权限")]
        public bool? IsHaveRole { get; set; }

        [Display(Name = "是否有权限")]
        public bool IsHaveRoleView { get; set; }
    }
}
