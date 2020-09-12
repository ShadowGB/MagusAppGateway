using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.Gateway.Models
{
    public class AddHeadersToRequest
    {
    }

    public class AddClaimsToRequest
    {
    }

    public class RouteClaimsRequirement
    {
    }

    public class AddQueriesToRequest
    {
    }

    public class FileCacheOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public int? TtlSeconds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Region { get; set; }
    }

    public class DownstreamHostAndPortsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Port { get; set; }
    }

    public class QoSOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public int? ExceptionsAllowedBeforeBreaking { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? DurationOfBreak { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TimeoutValue { get; set; }
    }

    public class RateLimitOptions
    {

        public RateLimitOptions()
        {
            ClientWhitelist = new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<string> ClientWhitelist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EnableRateLimiting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Period { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PeriodTimespan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Limit { get; set; }
    }

    public class AuthenticationOptions
    {
        public AuthenticationOptions()
        {
            AllowedScopes = new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string AuthenticationProviderKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> AllowedScopes { get; set; }
    }

    public class HttpHandlerOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string AllowAutoRedirect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UseCookieContainer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UseTracing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? MaxConnectionsPerServer { get; set; }
    }

    public class RoutesItem
    {
        public RoutesItem()
        {
            DownstreamHostAndPorts = new List<DownstreamHostAndPortsItem>();
            UpstreamHttpMethod = new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string DownstreamPathTemplate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UpstreamPathTemplate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> UpstreamHttpMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DownstreamHttpMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DownstreamHttpVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AddHeadersToRequest AddHeadersToRequest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AddClaimsToRequest AddClaimsToRequest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RouteClaimsRequirement RouteClaimsRequirement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AddQueriesToRequest AddQueriesToRequest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RequestIdKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FileCacheOptions FileCacheOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RouteIsCaseSensitive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DownstreamScheme { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DownstreamHostAndPortsItem> DownstreamHostAndPorts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public QoSOptions QoSOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public LoadBalancerOption LoadBalancerOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RateLimitOptions RateLimitOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AuthenticationOptions AuthenticationOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HttpHandlerOptions HttpHandlerOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DangerousAcceptAnyServerCertificateValidator { get; set; }
    }

    public class GlobalConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public string BaseUrl { get; set; }
    }

    public class LoadBalancerOption
    {
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
    }

    public class OcelotConfigModel
    {
        public OcelotConfigModel()
        {
            Routes = new List<RoutesItem>();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<RoutesItem> Routes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GlobalConfiguration GlobalConfiguration { get; set; }
    }

}
