using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientGrantTypeEditDto
    {
        [Display(Name = "授权方式")]
        public string GrantType { get; set; }
    }
}
