using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using MagusAppGateway.UI.IServices;
using Microsoft.AspNetCore.Components;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;

namespace MagusAppGateway.UI.Pages.Roles
{
    public partial class RoleList
    {
        [Inject]
        private IRoleService RoleService { get; set; }

        [Inject]
        public ToastService ToastService { get; set; }

        public Toast Toast { get; set; }

        private RoleDto SearchModel { get; set; } = new RoleDto();

        protected IEnumerable<RoleDto> SelectedRows { get; set; } = new List<RoleDto>();


        /// <summary>
        /// 分页参数
        /// </summary>
        protected IEnumerable<int> PageItemsSource => new int[] { 20, 40, 100, 200 };

        protected async Task<QueryData<RoleDto>> OnQueryAsync(QueryPageOptions options)
        {
            var result = await RoleService.GetRolePage(new RoleQueryDto
            {
                CurrentPage = options.PageIndex,
                PageSize = options.PageItems,
                RoleName = SearchModel.RoleName,
            });
            if (result.status.code == ResultCode.Success)
            {
                return new QueryData<RoleDto>
                {
                    Items = result.custom.Data,
                    TotalCount = result.custom.TotalCount,
                    IsSorted = false,
                    IsFiltered = false
                };
            }
            return null;
        }

        protected Task OnResetSearchAsync(RoleDto dto)
        {
            dto.RoleName = null;
            return Task.CompletedTask;
        }

        protected async Task<RoleDto> OnAddAsync()
        {
            return await Task.Run(() =>
            {
                if (SelectedRows.Count() == 0)
                {
                    return new RoleDto();
                }
                else if (SelectedRows.Count() == 1)
                {
                    var model = SelectedRows.First();
                    return model;
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
            });
        }

        protected async Task<bool> OnSaveAsync(RoleDto dto)
        {
            ResultModel<string> result = new ResultModel<string>();
            if (dto.Id == null)
            {
                result = await RoleService.AddRole(dto);
            }
            else
            {
                result = await RoleService.EditRole(dto);
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
