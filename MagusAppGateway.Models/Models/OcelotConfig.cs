using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.Models
{
    /// <summary>
    /// 网关配置主表
    /// </summary>
    public class OcelotConfig:BaseModel
    {
        public OcelotConfig()
        {
            Routes = new List<Routes>();
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Required]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 路由配置
        /// </summary>
        public List<Routes> Routes { get; set; }

        /// <summary>
        /// 全局配置
        /// </summary>
        public GlobalConfiguration GlobalConfiguration { get; set; }
    }

    /// <summary>
    /// 全局配置
    /// </summary>
    public class GlobalConfiguration : BaseModel
    {
        /// <summary>
        /// 网关地址
        /// </summary>
        [Required]
        [MaxLength(2000)]
        public string BaseUrl { get; set; }

        public OcelotConfig OcelotConfig { get; set; }

        public Guid OcelotConfigGuid { get; set; }
    }

    /// <summary>
    /// 路由配置
    /// </summary>
    public class Routes : BaseModel
    {
        public Routes()
        {
            DownstreamHostAndPorts = new List<DownstreamHostAndPorts>();
            UpstreamHttpMethods = new List<UpstreamHttpMethods>();
        }


        /// <summary>
        /// 下游路径模板
        /// </summary>
        [Required]
        [MaxLength(2000)]
        public string DownstreamPathTemplate { get; set; }

        /// <summary>
        /// 下游协议
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string DownstreamScheme { get; set; }

        /// <summary>
        /// 上游路径模板
        /// </summary>
        [Required]
        [MaxLength(2000)]
        public string UpstreamPathTemplate { get; set; }

        /// <summary>
        /// 下游服务地址
        /// </summary>
        public List<DownstreamHostAndPorts> DownstreamHostAndPorts { get; set; }

        public List<UpstreamHttpMethods> UpstreamHttpMethods { get; set; }

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        public bool RouteIsCaseSensitive { get; set; }

        /// <summary>
        /// 负载均衡配置
        /// </summary>
        public LoadBalancerOption LoadBalancerOption { get; set; }

        /// <summary>
        /// 授权配置
        /// </summary>
        public AuthenticationOptions AuthenticationOptions { get; set; }

        public Guid OcelotConfigGuid { get; set; }

        public OcelotConfig OcelotConfig { get; set; }
    }

    /// <summary>
    /// 负载均衡配置
    /// </summary>
    public class LoadBalancerOption : BaseModel
    {
        /// <summary>
        /// 负载均衡类型(LeastConnection、RoundRobin、NoLoadBalancer、CookieStickySessions)
        /// </summary>
        public string Type { get; set; }

        public Guid RoutesGuid { get; set; }

        public Routes Routes { get; set; }
    }

    /// <summary>
    /// 身份验证配置
    /// </summary>
    public class AuthenticationOptions : BaseModel
    {
        //public AuthenticationOptions()
        //{
        //    AllowedScopes = new List<string>();
        //}

        /// <summary>
        /// APIScope名称
        /// </summary>
        public string AuthenticationProviderKey { get; set; }

        /// <summary>
        /// 可以访问的APIScope，不用填
        /// </summary>
        //public List<string> AllowedScopes { get; set; }

        public Guid RoutesGuid { get; set; }

        public Routes Routes { get; set; }
    }

    /// <summary>
    /// 下游服务配置
    /// </summary>
    public class DownstreamHostAndPorts : BaseModel
    {

        /// <summary>
        /// 地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        public Guid RoutesGuid { get; set; }

        public Routes Routes { get; set; }
    }

    public class UpstreamHttpMethods : BaseModel
    {

        public string Method { get; set; }

        public Guid RoutesGuid { get; set; }

        public Routes Routes { get; set; }
    }
}
