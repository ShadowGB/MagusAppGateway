using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class RolesQueryDto : QueryModelBase
    {
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }

        [Display(Name ="用户编号")]
        public Guid UserId { get; set; }

        [Display(Name = "是否有角色")]
        public bool? IsHaveRole { get; set; }
    }
}
