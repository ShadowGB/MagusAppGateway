using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientCorsOriginEditDto
    {
        [Display(Name = "跨域配置")]
        public string Origin { get; set; }
    }
}
