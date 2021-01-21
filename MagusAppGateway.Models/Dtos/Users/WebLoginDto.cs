using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.Models.Dtos
{
    public class WebLoginDto
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Password { get; set; }
    }
}
