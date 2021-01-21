using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Responses;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MagusAppGateway.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MagusAppGateway.Gateway.Extensions
{
    public class PostgreSQLFileConfigurationRepository : IFileConfigurationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly UserDatabaseContext _userDatabaseContext;

        public PostgreSQLFileConfigurationRepository(IConfiguration configuration, UserDatabaseContext userDatabaseContext)
        {
            _configuration = configuration;
            _userDatabaseContext = userDatabaseContext;
        }

        public Task<Response<FileConfiguration>> Get()
        {
            var fileConfiguration = new FileConfiguration();
            var configModel = _userDatabaseContext.OcelotConfigs
                .Where(x => x.IsEnable == true)
                .Include(x => x.GlobalConfiguration).FirstOrDefault();

            if (configModel != null)
            {
                //全局配置
                var guid = configModel.Id;
                //var routes = _userDatabaseContext.Routes.Where(x => x.OcelotConfigGuid == guid)
                //    .Include(x => x.LoadBalancerOption)
                //    .Include(x => x.DownstreamPathTemplate)
                //    .Include(x => x.AuthenticationOptions).ToList();
                var routes = _userDatabaseContext.Routes.Where(x => x.OcelotConfigGuid == guid).ToList();
                configModel.Routes = routes;

                var fileGlobalConfiguration = new FileGlobalConfiguration();

                fileGlobalConfiguration.BaseUrl = configModel.GlobalConfiguration.BaseUrl;
                fileConfiguration.GlobalConfiguration = fileGlobalConfiguration;

                var routelist = new List<FileRoute>();
                foreach (var item in routes)
                {
                    item.LoadBalancerOption = _userDatabaseContext.LoadBalancerOptions.FirstOrDefault(x => x.RoutesGuid == item.Id);
                    item.AuthenticationOptions = _userDatabaseContext.AuthenticationOptions.FirstOrDefault(x => x.RoutesGuid == item.Id);
                    item.DownstreamHostAndPorts = _userDatabaseContext.DownstreamHostAndPorts.Where(x => x.RoutesGuid == item.Id).ToList();

                    var m = new FileRoute();
                    m.DownstreamPathTemplate = item.DownstreamPathTemplate;
                    m.DownstreamScheme = item.DownstreamScheme;
                    m.UpstreamPathTemplate = item.UpstreamPathTemplate;
                    m.UpstreamHttpMethod.AddRange(item.UpstreamHttpMethods.Select(x => x.Method));
                    m.RouteIsCaseSensitive = item.RouteIsCaseSensitive;
                    m.LoadBalancerOptions = new FileLoadBalancerOptions
                    {
                        Type = item.LoadBalancerOption.Type
                    };
                    m.AuthenticationOptions = new FileAuthenticationOptions
                    {
                        AuthenticationProviderKey = item.AuthenticationOptions.AuthenticationProviderKey,
                        AllowedScopes = new List<string> { }
                    };
                    var list = new List<FileHostAndPort>();
                    foreach(var hostItem in item.DownstreamHostAndPorts)
                    {
                        list.Add(new FileHostAndPort
                        {
                            Host = hostItem.Host,
                            Port = hostItem.Port
                        });
                    }
                    m.DownstreamHostAndPorts = list;
                    routelist.Add(m);
                }
                fileConfiguration.Routes = routelist;
            }
            else
            {
                throw new Exception("未监测到任何可用的配置信息");
            }
            if (fileConfiguration.Routes == null || fileConfiguration.Routes.Count == 0)
            {
                return Task.FromResult<Response<FileConfiguration>>(new OkResponse<FileConfiguration>(null));
            }
            return Task.FromResult<Response<FileConfiguration>>(new OkResponse<FileConfiguration>(fileConfiguration));
        }

        public Task<Response> Set(FileConfiguration fileConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}
