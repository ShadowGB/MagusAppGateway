using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class LoadBalancerOptionEditDto
    {
        public Guid? Id { get; set; }

        [Display(Name = "负载均衡类型")]
        public string Type { get; set; }

        public Guid? RoutesGuid { get; set; }

        public RoutesEditDto Routes { get; set; }
    }
}
