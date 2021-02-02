using System;

namespace MagusAppGateway.Models.Dtos
{
    public class DownstreamHostAndPortsEditDto
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        public Guid? RoutesGuid { get; set; }

        public RoutesEditDto Routes { get; set; }
    }
}
