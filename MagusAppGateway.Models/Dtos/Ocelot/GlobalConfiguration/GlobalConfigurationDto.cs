using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class GlobalConfigurationDto
    {
        public Guid Id { get; set; }

        public string BaseUrl { get; set; }

        public OcelotConfigDto OcelotConfig { get; set; }

        public Guid OcelotConfigGuid { get; set; }
    }
}
