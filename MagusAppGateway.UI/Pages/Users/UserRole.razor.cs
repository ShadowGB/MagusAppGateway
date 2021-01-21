using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using MagusAppGateway.UI.IServices;
using Microsoft.AspNetCore.Components;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;

namespace MagusAppGateway.UI.Pages.Users
{
    public partial class UserRole
    {
        [Inject]
        private IRoleService RoleService { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        [CascadingParameter(Name = "BodyContext")]
        private object param { get; set; }

        protected UserRoleDto SearchModel { get; set; } = new UserRoleDto();

        private List<UserRoleDto> userRoleDtos { get; set; } = new List<UserRoleDto>() { };

        private UserDto UserDto { get; set; } = new UserDto();

        protected IEnumerable<UserRoleDto> SelectedRows { get; set; } = new List<UserRoleDto>();

        [Parameter]
        public Action OnClose { get; set; }

        /// <summary>
        /// 分页参数
        /// </summary>
        protected IEnumerable<int> PageItemsSource => new int[] { 20, 40, 100, 200 };


        protected override async Task OnInitializedAsync()
        {
            UserDto = param as UserDto;
            await base.OnInitializedAsync();
        }

        protected async Task<QueryData<UserRoleDto>> OnQueryAsync(QueryPageOptions options)
        {
            var result = await RoleService.GetUserRoleAndIsHaveRoleByUserId(new UserRoleDto
            {
                UserId = UserDto.UserId,
                CurrentPage = options.PageIndex,
                PageSize = options.PageItems,
                RoleName = SearchModel.RoleName,
                IsHaveRole = SearchModel.IsHaveRole
            });
            if (result.status.code == ResultCode.Success)
            {
                userRoleDtos = result.custom;
                //result.custom.Data.ForEach(x => {
                //    x.IsHaveRoleView = x.IsHaveRole.Value;
                //});

                return new QueryData<UserRoleDto>
                {
                    Items = result.custom,
                    TotalCount = result.custom.Count,
                    IsSorted = false,
                    IsFiltered = false
                };
            }
            return null;
        }

        protected async Task SetRole()
        {
            OnClose?.Invoke();
            var model = new SetUserRoleDto();
            model.UserId = Guid.Parse(UserDto.UserId);
            if (SelectedRows != null && SelectedRows.Count() > 0)
            {
                SelectedRows.ToList().ForEach(x =>
                {
                    if (x != null)
                    {
                        model.RoleIds.Add(Guid.Parse(x.RoleId));
                    }
                });
            }
            var result = await RoleService.SetUserRoleByUserIdAndRoleIds(model);
            if (result.status.code == ResultCode.Success)
            {
                await ToastService.Show(new ToastOption()
                {
                    Title = "配置成功",
                    Content = "配置成功，4 秒后自动关闭"
                });
            }
            else
            {
                await ToastService.Show(new ToastOption()
                {
                    Title = "配置失败",
                    Content = $"配置失败，{result.status.text}"
                });
            }
        }

    }
}
