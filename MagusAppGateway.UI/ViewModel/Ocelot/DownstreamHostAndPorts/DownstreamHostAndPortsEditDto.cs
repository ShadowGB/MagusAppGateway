using System;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class DownstreamHostAndPortsEditDto
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        [Display(Name = "端口")]
        public int Port { get; set; }

        public Guid? RoutesGuid { get; set; }

        public RoutesEditDto Routes { get; set; }
    }
}
