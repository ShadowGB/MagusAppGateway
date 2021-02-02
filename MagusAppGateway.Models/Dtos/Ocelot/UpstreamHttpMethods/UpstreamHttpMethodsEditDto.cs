using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class UpstreamHttpMethodsEditDto
    {
        public Guid? Id { get; set; }

        public string Method { get; set; }

        public Guid? RoutesGuid { get; set; }

        public RoutesEditDto Routes { get; set; }
    }
}
