using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class LoadBalancerOptionDto
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public Guid RoutesGuid { get; set; }

        public RoutesDto Routes { get; set; }
    }
}
