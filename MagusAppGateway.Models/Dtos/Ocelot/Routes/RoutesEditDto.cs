using System;
using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class RoutesEditDto
    {

        public RoutesEditDto()
        {
            DownstreamHostAndPorts = new List<DownstreamHostAndPortsEditDto>();
            UpstreamHttpMethods = new List<UpstreamHttpMethodsEditDto>();
        }

        public Guid? Id { get; set; }

        /// <summary>
        /// 下游路径模板
        /// </summary>
        public string DownstreamPathTemplate { get; set; }

        /// <summary>
        /// 下游协议
        /// </summary>
        public string DownstreamScheme { get; set; }

        /// <summary>
        /// 上游路径模板
        /// </summary>
        public string UpstreamPathTemplate { get; set; }

        /// <summary>
        /// 下游服务地址
        /// </summary>
        public List<DownstreamHostAndPortsEditDto> DownstreamHostAndPorts { get; set; }

        public List<UpstreamHttpMethodsEditDto> UpstreamHttpMethods { get; set; }

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        public bool RouteIsCaseSensitive { get; set; }

        /// <summary>
        /// 负载均衡配置
        /// </summary>
        public LoadBalancerOptionEditDto LoadBalancerOption { get; set; }

        /// <summary>
        /// 授权配置
        /// </summary>
        public AuthenticationOptionsEditDto AuthenticationOptions { get; set; }

        public Guid OcelotConfigGuid { get; set; }
    }
}
