using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using MagusAppGateway.UI.IServices;
using Microsoft.AspNetCore.Components;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;

namespace MagusAppGateway.UI.Pages.Client
{
    public partial class ClientList
    {
        [Inject]
        private IClientService ClientService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected QueryData<ClientDto> Items { get; set; } = new QueryData<ClientDto>();

        protected ClientDto SearchModel { get; set; } = new ClientDto();

        protected IEnumerable<ClientDto> SelectedRows { get; set; } = new List<ClientDto>();

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
    }
}
