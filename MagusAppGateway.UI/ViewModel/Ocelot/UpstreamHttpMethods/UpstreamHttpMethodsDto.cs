using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class UpstreamHttpMethodsDto
    {
        public Guid Id { get; set; }

        public string Method { get; set; }

        public Guid RoutesGuid { get; set; }

        public RoutesDto Routes { get; set; }
    }
}
