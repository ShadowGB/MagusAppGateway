using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class RoutesEditDto
    {

        public RoutesEditDto()
        {
            DownstreamHostAndPorts = new List<DownstreamHostAndPortsEditDto>();
            UpstreamHttpMethods = new List<UpstreamHttpMethodsEditDto>();
        }

        [Display(Name = "编号")]
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
        public List<DownstreamHostAndPortsEditDto> DownstreamHostAndPorts { get; set; }

        public List<UpstreamHttpMethodsEditDto> UpstreamHttpMethods { get; set; }

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        [Display(Name = "区分大小写")]
        public bool RouteIsCaseSensitive { get; set; }

        /// <summary>
        /// 负载均衡配置
        /// </summary>
        public LoadBalancerOptionEditDto LoadBalancerOption { get; set; } = new LoadBalancerOptionEditDto();

        /// <summary>
        /// 授权配置
        /// </summary>
        public AuthenticationOptionsEditDto AuthenticationOptions { get; set; } = new AuthenticationOptionsEditDto();

        public Guid OcelotConfigGuid { get; set; }
    }
}
