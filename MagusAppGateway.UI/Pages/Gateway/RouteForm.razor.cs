using BootstrapBlazor.Components;
using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.Pages.Gateway
{
    public partial class RouteForm
    {
        [CascadingParameter(Name = "BodyContext")]
        private object param { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        [Inject]
        private IOcelotService OcelotService { get; set; }

        private RoutesEditDto RoutesEditDto { get; set; } = new RoutesEditDto();

        [Parameter]
        public Action OnClose { get; set; }

        private UpstreamHttpMethodsEditDto UpstreamHttpMethodsEditDto { get; set; } = new UpstreamHttpMethodsEditDto();

        private DownstreamHostAndPortsEditDto DownstreamHostAndPortsEditDto { get; set; } = new DownstreamHostAndPortsEditDto();

        private LoadBalancerOptionEditDto LoadBalancerOptionEditDto { get; set; } = new LoadBalancerOptionEditDto();

        private AuthenticationOptionsEditDto AuthenticationOptionsEditDto { get; set; } = new AuthenticationOptionsEditDto();

        //负载类型LeastConnection、RoundRobin、NoLoadBalancer、CookieStickySessions
        private IEnumerable<SelectedItem> LoadBalanceTypes => new List<SelectedItem>
        {
            new SelectedItem ("LeastConnection", "LeastConnection"),
            new SelectedItem ("RoundRobin", "RoundRobin"),
            new SelectedItem ("NoLoadBalancer", "NoLoadBalancer"),
            new SelectedItem ("CookieStickySessions", "CookieStickySessions")
        };

        private Task<bool> OnUpstreamHttpMethodsDelete(IEnumerable<UpstreamHttpMethodsEditDto> dtos)
        {
            dtos.ToList().ForEach(x => {
                RoutesEditDto.UpstreamHttpMethods.Remove(x);
            });
            return Task.FromResult(true);
        }

        private Task OnUpstreamHttpMethodsAdd()
        {
            RoutesEditDto.UpstreamHttpMethods.Add(new UpstreamHttpMethodsEditDto
            {
                Method = UpstreamHttpMethodsEditDto.Method
            });
            UpstreamHttpMethodsEditDto.Method = null;
            return Task.CompletedTask;
        }

        private Task<QueryData<UpstreamHttpMethodsEditDto>> OnUpstreamHttpMethodsQuery(QueryPageOptions options)
        {
            return Task.FromResult(new QueryData<UpstreamHttpMethodsEditDto>
            {
                Items = RoutesEditDto.UpstreamHttpMethods,
                TotalCount = RoutesEditDto.UpstreamHttpMethods.Count
            });
        }

        private Task<bool> OnDownstreamHostAndPortsDelete(IEnumerable<DownstreamHostAndPortsEditDto> dtos)
        {
            dtos.ToList().ForEach(x => {
                RoutesEditDto.DownstreamHostAndPorts.Remove(x);
            });
            return Task.FromResult(true);
        }

        private Task OnDownstreamHostAndPortsAdd()
        {
            RoutesEditDto.DownstreamHostAndPorts.Add(new DownstreamHostAndPortsEditDto
            {
                Host = DownstreamHostAndPortsEditDto.Host,
                Port = DownstreamHostAndPortsEditDto.Port
            });
            UpstreamHttpMethodsEditDto.Method = null;
            return Task.CompletedTask;
        }

        private Task<QueryData<DownstreamHostAndPortsEditDto>> OnDownstreamHostAndPortsQuery(QueryPageOptions options)
        {
            return Task.FromResult(new QueryData<DownstreamHostAndPortsEditDto>
            {
                Items = RoutesEditDto.DownstreamHostAndPorts,
                TotalCount = RoutesEditDto.DownstreamHostAndPorts.Count
            });
        }

        protected override async Task OnInitializedAsync()
        {
            if (param != null)
            {
                var model = param as RoutesDto;
                if (model.Id != null)
                {
                    var result = await OcelotService.GetRouteById(model.Id.Value);
                    if (result.status.code == ResultCode.Success)
                    {
                        var routesDto = result.custom;
                        RoutesEditDto.Id = routesDto.Id;
                        RoutesEditDto.DownstreamPathTemplate = routesDto.DownstreamPathTemplate;
                        RoutesEditDto.UpstreamPathTemplate = routesDto.UpstreamPathTemplate;
                        RoutesEditDto.RouteIsCaseSensitive = routesDto.RouteIsCaseSensitive.Value;
                        RoutesEditDto.DownstreamScheme = routesDto.DownstreamScheme;
                        LoadBalancerOptionEditDto = new LoadBalancerOptionEditDto
                        {
                            Id = routesDto.LoadBalancerOption.Id,
                            Type = routesDto.LoadBalancerOption.Type,
                            RoutesGuid = routesDto.LoadBalancerOption.RoutesGuid
                        };
                        AuthenticationOptionsEditDto = new AuthenticationOptionsEditDto
                        {
                            Id = routesDto.AuthenticationOptions.Id,
                            AuthenticationProviderKey = routesDto.AuthenticationOptions.AuthenticationProviderKey,
                            RoutesGuid = routesDto.AuthenticationOptions.Id
                        };

                        routesDto.DownstreamHostAndPorts.ForEach(x =>
                        {
                            RoutesEditDto.DownstreamHostAndPorts.Add(new DownstreamHostAndPortsEditDto
                            {
                                Id = x.Id,
                                Host = x.Host,
                                Port = x.Port,
                                RoutesGuid = x.RoutesGuid
                            });
                        });

                        routesDto.UpstreamHttpMethods.ForEach(x =>
                        {
                            RoutesEditDto.UpstreamHttpMethods.Add(new UpstreamHttpMethodsEditDto
                            {
                                Id = x.Id,
                                Method = x.Method,
                                RoutesGuid = x.RoutesGuid
                            });
                        });
                    }
                    else
                    {
                        await ToastService.Show(new ToastOption()
                        {
                            Title = "获取数据失败",
                            Content = $"获取数据失败，{result.status.text}",
                            Category = ToastCategory.Error
                        });
                    }
                }
            }
            await base.OnInitializedAsync();
        }

        private async Task OnSave()
        {
            ResultModel<string> result = new ResultModel<string>();
            if (RoutesEditDto.Id == null)
            {
                RoutesEditDto.OcelotConfigGuid = (param as RoutesDto).OcelotConfigGuid;
                RoutesEditDto.LoadBalancerOption = LoadBalancerOptionEditDto;
                RoutesEditDto.AuthenticationOptions = AuthenticationOptionsEditDto;
                result = await OcelotService.CreateRoute(RoutesEditDto);
            }
            else
            {
                RoutesEditDto.OcelotConfigGuid = (param as RoutesDto).OcelotConfigGuid;
                RoutesEditDto.LoadBalancerOption = LoadBalancerOptionEditDto;
                RoutesEditDto.AuthenticationOptions = AuthenticationOptionsEditDto;
                result = await OcelotService.UpdateRoute(RoutesEditDto);
            }
            if (result.status.code == ResultCode.Success)
            {
                OnClose?.Invoke();
                await ToastService.Show(new ToastOption()
                {
                    Title = "保存成功",
                    Content = "保存成功，4 秒后自动关闭"
                });
            }
            else
            {
                await ToastService.Show(new ToastOption()
                {
                    Title = "保存失败",
                    Content = $"保存失败，{result.status.text}",
                    Category = ToastCategory.Error
                });
            }
            await Task.CompletedTask;
        }
    }
}
