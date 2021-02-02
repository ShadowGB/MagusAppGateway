using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using MagusAppGateway.UI.IServices;
using Microsoft.AspNetCore.Components;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;
using IdentityServer4.Models;

namespace MagusAppGateway.UI.Pages.Gateway
{
    public partial class OcelotList
    {
        [Inject]
        private IOcelotService OcelotService { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public ToastService ToastService { get; set; }

        protected RoutesDto SearchModel { get; set; } = new RoutesDto();

        private Table<RoutesDto> Table { get; set; }

        protected IEnumerable<RoutesDto> SelectedRows { get; set; } = new List<RoutesDto>();

        private Guid SelectedConfigId { get; set; } = new Guid();

        /// <summary>
        /// 分页参数
        /// </summary>
        protected IEnumerable<int> PageItemsSource => new int[] { 20, 40, 100, 200 };

        private List<SelectedItem> ConfigItems { get; set; } = new List<SelectedItem>();


        protected async Task<QueryData<RoutesDto>> OnQueryAsync(QueryPageOptions options)
        {
            var result = await OcelotService.GetRoutePageList(new RoutesQueryDto
            {
                CurrentPage = options.PageIndex,
                PageSize = options.PageItems,
                OcelotConfigId = SelectedConfigId,
                
            });
            if (result.status.code == ResultCode.Success)
            {
                return new QueryData<RoutesDto>
                {
                    Items = result.custom.Data,
                    TotalCount = result.custom.TotalCount,
                    IsSorted = false,
                    IsFiltered = false
                };
            }
            return null;
        }

        protected override async Task OnInitializedAsync()
        {
            await GetConfig();
            await base.OnInitializedAsync();
        }

        private async Task GetConfig()
        {
            var configList = await OcelotService.GetAllConfig();
            if (configList.status.code == ResultCode.Success)
            {
                configList.custom.ForEach(x =>
                {
                    ConfigItems.Add(new SelectedItem
                    {
                        Text = x.ConfigName,
                        Value = x.Id.ToString(),
                        Active = x.IsEnable.Value
                    });
                });
            }
        }

        protected async Task OnAdd(IEnumerable<RoutesDto> dtos)
        {
            var option = new DialogOption()
            {
                Title = "新增路由",
                Size = Size.ExtraLarge,
                BodyContext = new RoutesDto
                {
                    OcelotConfigGuid = SelectedConfigId
                }
            };
            option.BodyTemplate = DynamicComponent.CreateComponent<RouteForm>(new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>(nameof(RouteForm.OnClose),new Action(async ()=>{ await Table.QueryAsync(); option.Dialog?.Close(); }))
            }).Render();
            await DialogService.Show(option);
        }


        protected async Task OnEdit(RoutesDto dto)
        {
            var option = new DialogOption()
            {
                Title = "编辑路由",
                Size = Size.ExtraLarge,
                BodyContext = dto
            };
            option.BodyTemplate = DynamicComponent.CreateComponent<RouteForm>(new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>(nameof(RouteForm.OnClose),new Action(async ()=>{ await Table.QueryAsync(); option.Dialog?.Close(); }))
            }).Render();
            await DialogService.Show(option);
        }

        protected async Task<bool> OnDelete(IEnumerable<RoutesDto> dto)
        {
            var model = dto.FirstOrDefault();
            if (model != null)
            {
                var result = await OcelotService.DelteRoute(model.Id.Value);
                if(result.status.code==ResultCode.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

