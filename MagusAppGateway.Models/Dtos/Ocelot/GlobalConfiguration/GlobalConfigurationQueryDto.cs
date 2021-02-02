using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class GlobalConfigurationQueryDto : QueryModelBase
    {
        public string BaseUrl { get; set; }
    }
}
