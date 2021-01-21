using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.Models.Dtos
{
    public class UserDto
    {
        [Display(Name = "编号")]
        public string UserId { get; set; }

        [Display(Name = "用户名")]
        public string Username { get; set; }

        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "是否启用")]
        public bool? Enabled { get; set; }
    }
}
