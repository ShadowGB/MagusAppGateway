using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientPostLogoutRedirectUriEditDto
    {
        [Display(Name = "登出回调地址")]
        public string PostLogoutRedirectUri { get; set; }
    }
}
