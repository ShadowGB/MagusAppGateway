using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class GlobalConfigurationQueryDto : QueryModelBase
    {
        public string BaseUrl { get; set; }
    }
}
