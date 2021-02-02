using System;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class GlobalConfigurationDto
    {
        [Display(Name = "编号")]
        public Guid Id { get; set; }

        [Display(Name = "网关地址")]
        public string BaseUrl { get; set; }

        public OcelotConfigDto OcelotConfig { get; set; }

        public Guid OcelotConfigGuid { get; set; }
    }
}
