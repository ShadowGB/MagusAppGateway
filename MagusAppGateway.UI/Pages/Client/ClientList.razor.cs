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

namespace MagusAppGateway.UI.Pages.Client
{
    public partial class ClientList
    {
        [Inject]
        private IClientService ClientService { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public ToastService ToastService { get; set; }

        protected QueryData<ClientDto> Items { get; set; } = new QueryData<ClientDto>();

        protected ClientDto SearchModel { get; set; } = new ClientDto();

        protected IEnumerable<ClientDto> SelectedRows { get; set; } = new List<ClientDto>();

        public Toast Toast { get; set; }

        private Table<ClientDto> Table { get; set; }

        /// <summary>
        /// 分页参数
        /// </summary>
        protected IEnumerable<int> PageItemsSource => new int[] { 20, 40, 100, 200 };


        protected async Task<QueryData<ClientDto>> OnQueryAsync(QueryPageOptions options)
        {
            var result = await ClientService.GetClientPage(new ClientQueryDto
            {
                CurrentPage = options.PageIndex,
                PageSize = options.PageItems,
                ClientId = SearchModel.ClientId,
                Enabled = SearchModel.Enabled,
            });
            if (result.status.code == ResultCode.Success)
            {
                return new QueryData<ClientDto>
                {
                    Items = result.custom.Data,
                    TotalCount = result.custom.TotalCount,
                    IsSorted = false,
                    IsFiltered = false
                };
            }
            return null;
        }


        protected async Task OnAdd(IEnumerable<ClientDto> dtos)
        {
            var option = new DialogOption()
            {
                Title = "新增客户端",
                Size = Size.ExtraLarge,
                BodyContext = dtos.FirstOrDefault()
            };
            option.BodyTemplate = DynamicComponent.CreateComponent<ClientForm>(new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>(nameof(ClientForm.OnClose),new Action(async ()=>{ await Table.QueryAsync(); option.Dialog?.Close(); }))
            }).Render();
            await DialogService.Show(option);
        }

        protected async Task OnEdit(ClientDto dto)
        {
            var option = new DialogOption()
            {
                Title = "编辑客户端",
                Size = Size.ExtraLarge,
                BodyContext = dto
            };
            option.BodyTemplate = DynamicComponent.CreateComponent<ClientForm>(new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>(nameof(ClientForm.OnClose),new Action(async ()=>{ await Table.QueryAsync(); option.Dialog?.Close(); }))
            }).Render();
            await DialogService.Show(option);
        }
    }
}
