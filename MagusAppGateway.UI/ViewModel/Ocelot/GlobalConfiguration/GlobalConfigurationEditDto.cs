using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class GlobalConfigurationEditDto
    {
        public Guid? Id { get; set; }

        public string BaseUrl { get; set; }

        public OcelotConfigEditDto OcelotConfig { get; set; }

        public Guid? OcelotConfigGuid { get; set; }
    }
}
