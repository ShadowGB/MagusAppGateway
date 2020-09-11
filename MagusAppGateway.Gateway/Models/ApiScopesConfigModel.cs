using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.Gateway.Models
{
    public class ApiScopesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string AuthenticationProviderKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ApiName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ApiSecret { get; set; }
    }

    public class ApiScopesConfigModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ApiScopesItem> ApiScopes { get; set; }
    }
}
