using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using MagusAppGateway.UI.IServices;
using Microsoft.AspNetCore.Components;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;

namespace MagusAppGateway.UI.Pages.ApiScope
{
    public partial class ApiList
    {
        [Inject]
        private IApiScopeService ApiScopeService { get; set; }

        [Inject]
        public ToastService ToastService { get; set; }

        public Toast Toast { get; set; }

        protected ApiScopeDto SearchModel { get; set; } = new ApiScopeDto();

        protected IEnumerable<ApiScopeDto> SelectedRows { get; set; } = new List<ApiScopeDto>();

        /// <summary>
        /// 分页参数
        /// </summary>
        protected IEnumerable<int> PageItemsSource => new int[] { 20, 40, 100, 200 };


        protected async Task<QueryData<ApiScopeDto>> OnQueryAsync(QueryPageOptions options)
        {
            var result = await ApiScopeService.GetApiScopePage(new ApiScopeQueryDto
            {
                CurrentPage = options.PageIndex,
                PageSize = options.PageItems,
                Name = SearchModel.Name,
            });
            if (result.status.code == ResultCode.Success)
            {
                return new QueryData<ApiScopeDto>
                {
                    Items = result.custom.Data,
                    TotalCount = result.custom.TotalCount,
                    IsSorted = false,
                    IsFiltered = false
                };
            }
            return null;
        }

        protected Task OnResetSearchAsync(ApiScopeDto dto)
        {
            dto.Name = null;
            return Task.CompletedTask;
        }

        protected Task<ApiScopeDto> OnAddAsync()
        {
            if (SelectedRows.Count() == 0)
            {
                return Task.FromResult(new ApiScopeDto());
            }
            else if (SelectedRows.Count() == 1)
            {
                var model = SelectedRows.First();
                return Task.FromResult(model);
            }
            else
            {
                Toast?.SetPlacement(Placement.TopEnd);
                ToastService?.Show(new ToastOption()
                {
                    Category = ToastCategory.Error,
                    Title = "保存失败",
                    Content = "只能选择一条数据"
                });
                return null;
            }
        }

        protected async Task<bool> OnSaveAsync(ApiScopeDto dto)
        {
            ResultModel<string> result = new ResultModel<string>();
            var model = new ApiScopeEditDto()
            {
                Enabled = dto.Enabled,
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Description = dto.Description
            };
            if (dto.Id == null)
            {
                model.Id = 0;
                result = await ApiScopeService.AddApiScope(model);
            }
            else
            {
                model.Id = dto.Id;
                result = await ApiScopeService.EditApiScope(model);
            }
            if (result.status.code == ResultCode.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
