using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.ViewModel
{
    public class UserBase
    {
        [Display(Name = "编号")]
        public string UserId { get; set; }

        [Display(Name = "用户名")]
        public string Username { get; set; }

        [Display(Name = "密码")]
        public string Password { get; set; }

        //[Display(Name = "是否启用")]
        //public bool? Enabled { get; set; }
    }
}
