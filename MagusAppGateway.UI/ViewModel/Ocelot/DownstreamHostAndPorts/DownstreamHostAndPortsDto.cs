using System;

namespace MagusAppGateway.UI.ViewModel
{
    public class DownstreamHostAndPortsDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        public Guid RoutesGuid { get; set; }

        public RoutesDto Routes { get; set; }
    }
}
