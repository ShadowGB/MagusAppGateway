using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientRedirectUriEditDto
    {
        [Display(Name ="登录回调地址")]
        public string RedirectUri { get; set; }
    }
}
