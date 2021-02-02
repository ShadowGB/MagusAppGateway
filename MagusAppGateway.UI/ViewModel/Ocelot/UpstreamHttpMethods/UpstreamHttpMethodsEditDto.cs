using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class UpstreamHttpMethodsEditDto
    {
        public Guid? Id { get; set; }

        [Display(Name = "HTTP方法")]
        public string Method { get; set; }

        public Guid? RoutesGuid { get; set; }

        public RoutesEditDto Routes { get; set; }
    }
}
