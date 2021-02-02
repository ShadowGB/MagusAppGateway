using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientScopeEditDto
    {
        [Display(Name = "API域")]
        public string Scope { get; set; }
    }
}
