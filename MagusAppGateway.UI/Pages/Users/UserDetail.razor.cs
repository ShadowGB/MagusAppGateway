using BootstrapBlazor.Components;
using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.Pages.Users
{
    public partial class UserDetail
    {
        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        private IRoleService RoleService { get; set; }

        [Inject]
        protected ToastService ToastService { get; set; }

        [Parameter]
        public Action OnClose { get; set; }
        protected QueryData<UserRoleDto> Items { get; set; } = new QueryData<UserRoleDto>();
        protected UserRoleDto SearchModel { get; set; } = new UserRoleDto();

        /// <summary>
        /// 分页参数
        /// </summary>
        protected IEnumerable<int> PageItemsSource => new int[] { 20, 40, 100, 200 };

        [CascadingParameter(Name = "BodyContext")]
        private object param { get; set; }

        private UserDto UserDto { get; set; }


        private UserDto Model { get; set; } = new UserDto();

        protected override async Task OnInitializedAsync()
        {
            UserDto = param as UserDto;
            if (UserDto != null)
            {
                var result = await UserService.GetUserById(UserDto.UserId.ToString());
                if(result.status.code == ResultCode.Success)
                {
                    Model = result.custom;
                    Model.EnabledAddOrEdit = Model.Enabled.Value;
                }
            }
            await base.OnInitializedAsync();
        }


        protected async Task<QueryData<UserRoleDto>> OnQueryAsync(QueryPageOptions options)
        {
            var result = await RoleService.GetUserRole(new UserRoleDto
            {
                UserId = UserDto.UserId,
                CurrentPage = options.PageIndex,
                PageSize = options.PageItems,
                RoleName = SearchModel.RoleName,
                IsHaveRole = SearchModel.IsHaveRole
            });
            if (result.status.code == ResultCode.Success)
            {
                result.custom.Data.ForEach(x => {
                    x.IsHaveRoleView = x.IsHaveRole.Value;
                });

                return new QueryData<UserRoleDto>
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
