using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class RoutesDto
    {

        public RoutesDto()
        {
            DownstreamHostAndPorts = new List<DownstreamHostAndPortsDto>();
            UpstreamHttpMethods = new List<UpstreamHttpMethodsDto>();
        }

        [Display(Name ="编号")]
        public Guid? Id { get; set; }

        /// <summary>
        /// 下游路径模板
        /// </summary>
        [Display(Name = "下游路径模板")]
        public string DownstreamPathTemplate { get; set; }

        /// <summary>
        /// 下游协议
        /// </summary>
        [Display(Name = "下游协议")]
        public string DownstreamScheme { get; set; }

        /// <summary>
        /// 上游路径模板
        /// </summary>
        [Display(Name = "上游路径模板")]
        public string UpstreamPathTemplate { get; set; }

        /// <summary>
        /// 下游服务地址
        /// </summary>
        public List<DownstreamHostAndPortsDto> DownstreamHostAndPorts { get; set; }

        public List<UpstreamHttpMethodsDto> UpstreamHttpMethods { get; set; }

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        [Display(Name = "是否区分大小写")]
        public bool? RouteIsCaseSensitive { get; set; }

        /// <summary>
        /// 负载均衡配置
        /// </summary>
        public LoadBalancerOptionDto LoadBalancerOption { get; set; }

        /// <summary>
        /// 授权配置
        /// </summary>
        public AuthenticationOptionsDto AuthenticationOptions { get; set; }

        public Guid OcelotConfigGuid { get; set; }

        public OcelotConfigDto OcelotConfig { get; set; }
    }
}
