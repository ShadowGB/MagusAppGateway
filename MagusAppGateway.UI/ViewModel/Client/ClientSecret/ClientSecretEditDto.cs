using System;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientSecretEditDto
    {
        [Display(Name ="描述")]
        public string Description { get; set; }

        [Display(Name = "秘钥")]
        public string Value { get; set; }

        [Display(Name = "过期时间")]
        public DateTime Expiration { get; set; }

        [Display(Name = "创建时间")]
        public DateTime Created { get; set; }
    }
}
