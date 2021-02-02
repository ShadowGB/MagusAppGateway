using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.ViewModel
{
    public static class GrantTypes
    {
        public static IEnumerable<string> GrantTypeList => new List<string> 
        { 
            "Implicit", 
            "ImplicitAndClientCredentials",
            "Code",
            "CodeAndClientCredentials",
            "Hybrid", 
            "HybridAndClientCredentials", 
            "ClientCredentials", 
            "ResourceOwnerPassword", 
            "ResourceOwnerPasswordAndClientCredentials", 
            "DeviceFlow" 
        };
    }
}
