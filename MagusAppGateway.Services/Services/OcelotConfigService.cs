using System;
using System.Linq;
using System.Threading.Tasks;
using MagusAppGateway.Services.IServices;
using Microsoft.EntityFrameworkCore;
using MagusAppGateway.Contexts;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Util.Result;
using MagusAppGateway.Models;
using System.Collections.Generic;

namespace MagusAppGateway.Services.Services
{
    public class OcelotConfigService : IOcelotConfigService
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public OcelotConfigService(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        public async Task<ResultModel> CreateConfig(OcelotConfigEditDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.GlobalConfiguration.BaseUrl))
            {
                return new ResultModel(ResultCode.Fail, "请输入网关地址");
            }
            var globalConfiguration = new GlobalConfiguration
            {
                BaseUrl = dto.GlobalConfiguration.BaseUrl
            };
            var ocelotConfig = new OcelotConfig
            {
                IsEnable = dto.IsEnable,
                GlobalConfiguration = globalConfiguration
            };
            try
            {
                _userDatabaseContext.OcelotConfigs.Add(ocelotConfig);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "创建网关配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> CreateRoute(RoutesEditDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.DownstreamPathTemplate))
            {
                return new ResultModel(ResultCode.Fail, "请输入下游路径模板");
            }
            if (string.IsNullOrWhiteSpace(dto.DownstreamScheme))
            {
                return new ResultModel(ResultCode.Fail, "请输入下游HTTP协议");
            }
            if (string.IsNullOrWhiteSpace(dto.UpstreamPathTemplate))
            {
                return new ResultModel(ResultCode.Fail, "请输入上游路径模板");
            }
            var model = new Routes();

            model.Id = Guid.NewGuid();
            model.OcelotConfigGuid = dto.OcelotConfigGuid;
            model.DownstreamPathTemplate = dto.DownstreamPathTemplate;
            model.DownstreamScheme = dto.DownstreamScheme;
            model.UpstreamPathTemplate = dto.UpstreamPathTemplate;
            model.RouteIsCaseSensitive = dto.RouteIsCaseSensitive;
            model.LoadBalancerOption = new LoadBalancerOption
            {
                Id = Guid.NewGuid(),
                Type = dto.LoadBalancerOption.Type,
                RoutesGuid = model.Id
            };

            if (!string.IsNullOrWhiteSpace(dto.AuthenticationOptions.AuthenticationProviderKey))
            {
                model.AuthenticationOptions = new AuthenticationOptions
                {
                    Id = Guid.NewGuid(),
                    AuthenticationProviderKey = dto.AuthenticationOptions.AuthenticationProviderKey,
                    RoutesGuid = model.Id
                };
            }
            dto.DownstreamHostAndPorts.ForEach(x =>
            {
                model.DownstreamHostAndPorts.Add(new DownstreamHostAndPorts
                {
                    Id = new Guid(),
                    Host = x.Host,
                    Port = x.Port,
                    RoutesGuid = model.Id
                });
            });
            dto.UpstreamHttpMethods.ForEach(x =>
            {
                model.UpstreamHttpMethods.Add(new UpstreamHttpMethods
                {
                    Id = new Guid(),
                    Method = x.Method,
                    RoutesGuid = model.Id
                });
            });
            try
            {
                _userDatabaseContext.Routes.Add(model);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "创建路由成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> DeleteConfig(Guid id)
        {
            try
            {
                _userDatabaseContext.OcelotConfigs.Remove(_userDatabaseContext.OcelotConfigs.FirstOrDefault(x => x.Id == id));
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "删除网关配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> DelteRoute(Guid id)
        {
            try
            {
                _userDatabaseContext.Routes.Remove(_userDatabaseContext.Routes.FirstOrDefault(x => x.Id == id));
                _ = await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "删除路由成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> EnableConfig(Guid id)
        {
            var list = _userDatabaseContext.OcelotConfigs.Where(x => 1 == 1);
            foreach (var item in list)
            {
                if (item.Id != id)
                {
                    item.IsEnable = false;
                }
                else
                {
                    item.IsEnable = true;
                }
            };
            try
            {
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "启用配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetAllConfig()
        {
            return await Task.Run(() =>
            {
                try
                {
                    var config = _userDatabaseContext.OcelotConfigs.Where(x => 1 == 1)
                            .Select(x => new OcelotConfigDto
                            {
                                Id = x.Id,
                                ConfigName = x.ConfigName,
                                IsEnable = x.IsEnable
                            });
                    return new ResultModel(ResultCode.Success, config);
                }
                catch (Exception ex)
                {
                    return new ResultModel(ResultCode.Fail, ex.Message);
                }
            });
        }

        public async Task<ResultModel> GetConfigById(Guid id)
        {
            try
            {
                var config = await _userDatabaseContext.OcelotConfigs
                        .Include(x => x.GlobalConfiguration)
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (config == null)
                {
                    return new ResultModel(ResultCode.Fail, "没有对应配置");
                }
                var ocelotConfigDto = new OcelotConfigDto
                {
                    Id = config.Id,
                    ConfigName = config.ConfigName,
                    IsEnable = config.IsEnable,
                    GlobalConfiguration = new GlobalConfigurationDto
                    {
                        Id = config.GlobalConfiguration.Id,
                        BaseUrl = config.GlobalConfiguration.BaseUrl,
                        OcelotConfigGuid = config.Id
                    }
                };
                return new ResultModel(ResultCode.Success, ocelotConfigDto);
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetConfigPageList(OcelotConfigQueryDto dto)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var query = _userDatabaseContext.OcelotConfigs.Include(x => x.GlobalConfiguration).Where(x => 1 == 1);
                    if (dto.IsEnable != null)
                    {
                        query = query.Where(x => x.IsEnable == dto.IsEnable);
                    }
                    if (!string.IsNullOrWhiteSpace(dto.ConfigName))
                    {
                        query = query.Where(x => x.ConfigName.Contains(dto.ConfigName));
                    }
                    var list = query.Select(x => new OcelotConfigDto
                    {
                        Id = x.Id,
                        IsEnable = x.IsEnable,
                        ConfigName = x.ConfigName,
                        GlobalConfiguration = new GlobalConfigurationDto
                        {
                            BaseUrl = x.GlobalConfiguration.BaseUrl,
                            Id = x.GlobalConfiguration.Id,
                            OcelotConfigGuid = x.GlobalConfiguration.OcelotConfigGuid
                        }
                    });
                    var page = PagedList<OcelotConfigDto>.ToPagedList(list, dto.CurrentPage, dto.PageSize);
                    return new ResultModel(ResultCode.Success, page);
                }
                catch (Exception ex)
                {
                    return new ResultModel(ResultCode.Fail, ex.Message);
                }
            });
        }

        public async Task<ResultModel> GetRouteById(Guid id)
        {
            try
            {
                var route = await _userDatabaseContext.Routes.Where(x => x.Id == id)
                        .Include(x => x.AuthenticationOptions)
                        .Include(x => x.DownstreamHostAndPorts)
                        .Include(x => x.LoadBalancerOption)
                        .Include(x => x.UpstreamHttpMethods)
                        .FirstOrDefaultAsync();
                if (route == null)
                {
                    return new ResultModel(ResultCode.Fail, "没有对应路由");
                }
                var routeDto = new RoutesDto
                {
                    Id = route.Id,
                    DownstreamPathTemplate = route.DownstreamPathTemplate,
                    DownstreamScheme = route.DownstreamScheme,
                    UpstreamPathTemplate = route.UpstreamPathTemplate,
                    RouteIsCaseSensitive = route.RouteIsCaseSensitive
                };

                if (route.LoadBalancerOption != null)
                {

                    routeDto.LoadBalancerOption = new LoadBalancerOptionDto
                    {
                        Id = route.LoadBalancerOption.Id,
                        Type = route.LoadBalancerOption.Type,
                        RoutesGuid = route.Id
                    };
                }

                if (route.AuthenticationOptions != null)
                {
                    routeDto.AuthenticationOptions = new AuthenticationOptionsDto
                    {
                        Id = route.AuthenticationOptions.Id,
                        AuthenticationProviderKey = route.AuthenticationOptions.AuthenticationProviderKey,
                        RoutesGuid = route.Id
                    };
                }

                route.DownstreamHostAndPorts.ForEach(x =>
                {
                    routeDto.DownstreamHostAndPorts.Add(new DownstreamHostAndPortsDto
                    {
                        Id = x.Id,
                        Host = x.Host,
                        Port = x.Port,
                        RoutesGuid = x.RoutesGuid
                    });
                });

                route.UpstreamHttpMethods.ForEach(x =>
                {
                    routeDto.UpstreamHttpMethods.Add(new UpstreamHttpMethodsDto
                    {
                        Id = x.Id,
                        Method = x.Method,
                        RoutesGuid = x.RoutesGuid
                    });
                });
                return new ResultModel(ResultCode.Success, routeDto);
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetRoutePageList(RoutesQueryDto dto)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var query = _userDatabaseContext.Routes.Where(x => 1 == 1);
                    if (dto.OcelotConfigId != Guid.Empty)
                    {
                        query = query.Where(x => x.OcelotConfigGuid == dto.OcelotConfigId);
                    }
                    else
                    {
                        var model = await _userDatabaseContext.OcelotConfigs.Where(x => x.IsEnable == true).FirstOrDefaultAsync();
                        query = query.Where(x => x.OcelotConfigGuid == model.Id);
                    }
                    var list = query.Select(x => new RoutesDto
                    {
                        Id = x.Id,
                        DownstreamPathTemplate = x.DownstreamPathTemplate,
                        UpstreamPathTemplate = x.UpstreamPathTemplate,
                        DownstreamScheme = x.DownstreamScheme,
                        RouteIsCaseSensitive = x.RouteIsCaseSensitive,
                        OcelotConfigGuid = x.OcelotConfigGuid
                    });
                    var page = PagedList<RoutesDto>.ToPagedList(list, dto.CurrentPage, dto.PageSize);
                    return new ResultModel(ResultCode.Success, page);
                }
                catch (Exception ex)
                {
                    return new ResultModel(ResultCode.Fail, ex.Message);
                }
            });
        }

        public async Task<ResultModel> UpdateConfig(OcelotConfigEditDto dto)
        {
            var configModel = await _userDatabaseContext.OcelotConfigs.Include(x => x.GlobalConfiguration).FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (configModel == null)
            {
                return new ResultModel(ResultCode.Fail, "没有对应网关配置");
            }
            configModel.IsEnable = dto.IsEnable;
            configModel.GlobalConfiguration.BaseUrl = dto.GlobalConfiguration.BaseUrl;
            try
            {
                _userDatabaseContext.OcelotConfigs.Update(configModel);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新网关配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> UpdateRoute(RoutesEditDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.DownstreamPathTemplate))
            {
                return new ResultModel(ResultCode.Fail, "请输入下游路径模板");
            }
            if (string.IsNullOrWhiteSpace(dto.DownstreamScheme))
            {
                return new ResultModel(ResultCode.Fail, "请输入下游HTTP协议");
            }
            if (string.IsNullOrWhiteSpace(dto.UpstreamPathTemplate))
            {
                return new ResultModel(ResultCode.Fail, "请输入上游路径模板");
            }
            if (dto.DownstreamHostAndPorts == null || dto.DownstreamHostAndPorts.Count <= 0)
            {
                return new ResultModel(ResultCode.Fail, "请填写至少一个下游地址");
            }
            if (dto.UpstreamHttpMethods == null || dto.UpstreamHttpMethods.Count <= 0)
            {
                return new ResultModel(ResultCode.Fail, "请填写至少一个上游HTTP方法");
            }

            try
            {
                var routeModel = await _userDatabaseContext.Routes.Where(x => x.Id == dto.Id)
                .Include(x => x.AuthenticationOptions)
                .Include(x => x.DownstreamHostAndPorts)
                .Include(x => x.LoadBalancerOption)
                .Include(x => x.UpstreamHttpMethods)
                .FirstOrDefaultAsync();

                routeModel.DownstreamPathTemplate = dto.DownstreamPathTemplate;
                routeModel.DownstreamScheme = dto.DownstreamScheme;
                routeModel.UpstreamPathTemplate = dto.UpstreamPathTemplate;
                routeModel.RouteIsCaseSensitive = dto.RouteIsCaseSensitive;

                routeModel.LoadBalancerOption = null;
                routeModel.AuthenticationOptions = null;
                routeModel.DownstreamHostAndPorts = null;
                routeModel.UpstreamHttpMethods = null;

                var loadBalancerOption = new LoadBalancerOption
                {
                    Id = new Guid(),
                    Type = dto.LoadBalancerOption.Type,
                    RoutesGuid = routeModel.Id
                };
                routeModel.LoadBalancerOption = loadBalancerOption;
                if (!string.IsNullOrWhiteSpace(dto.AuthenticationOptions.AuthenticationProviderKey))
                {
                    routeModel.AuthenticationOptions = new AuthenticationOptions
                    {
                        AuthenticationProviderKey = dto.AuthenticationOptions.AuthenticationProviderKey,
                        RoutesGuid = routeModel.Id
                    };
                }

                var downstreamHostAndPorts = new List<DownstreamHostAndPorts> { };
                dto.DownstreamHostAndPorts.ForEach(x =>
                {
                    downstreamHostAndPorts.Add(new DownstreamHostAndPorts
                    {
                        Host = x.Host,
                        Port = x.Port
                    });
                });

                var upstreamHttpMethods = new List<UpstreamHttpMethods> { };
                dto.UpstreamHttpMethods.ForEach(x =>
                {
                    upstreamHttpMethods.Add(new UpstreamHttpMethods
                    {
                        Method = x.Method,
                        RoutesGuid = routeModel.Id
                    });
                });

                routeModel.DownstreamHostAndPorts = downstreamHostAndPorts;
                routeModel.UpstreamHttpMethods = upstreamHttpMethods;

                _userDatabaseContext.Routes.Update(routeModel);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新路由配置成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }
    }
}
