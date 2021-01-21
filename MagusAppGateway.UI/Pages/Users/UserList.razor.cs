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
    public partial class UserList
    {
        [Inject]
        private IUserService UserService { get; set; }

        [Inject]
        public ToastService ToastService { get; set; }

        public Toast Toast { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected QueryData<UserDto> Items { get; set; } = new QueryData<UserDto>();

        protected UserDto SearchModel { get; set; } = new UserDto();

        protected IEnumerable<UserDto> SelectedRows { get; set; } = new List<UserDto>();

        /// <summary>
        /// 分页参数
        /// </summary>
        protected IEnumerable<int> PageItemsSource => new int[] { 20, 40, 100, 200 };

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected async Task<QueryData<UserDto>> OnQueryAsync(QueryPageOptions options)
        {
            var result = await UserService.GetUserPage(new UserQueryDto
            {
                CurrentPage = options.PageIndex,
                PageSize = options.PageItems,
                Username = SearchModel.Username,
                Enabled = SearchModel.Enabled,
            });
            if (result.status.code == ResultCode.Success)
            {
                foreach (var item in result.custom.Data)
                {
                    item.EnabledAddOrEdit = item.Enabled.Value;
                }

                return new QueryData<UserDto>
                {
                    Items = result.custom.Data,
                    TotalCount = result.custom.TotalCount,
                    IsSorted = false,
                    IsFiltered = false
                };
            }
            return null;
        }

        protected Task OnResetSearchAsync(UserDto userDto)
        {
            userDto.Enabled = null;
            userDto.Username = null;
            return Task.CompletedTask;
        }

        protected Task<UserDto> OnAddAsync()
        {
            if (SelectedRows.Count() == 0)
            {
                return Task.FromResult(new UserDto());
            }
            else if (SelectedRows.Count() == 1)
            {
                var model = SelectedRows.First();
                return Task.FromResult(
                    new UserDto
                    {
                        //Id = model.Id,
                        Username = model.Username,
                        EnabledAddOrEdit = model.Enabled.Value,
                        Enabled = model.Enabled
                    });
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

        protected async Task<bool> OnSaveAsync(UserDto userDto)
        {
            var userCreateOrEditDto = new UserCreateOrEditDto
            {
                Id = Guid.Parse(userDto.UserId),
                Username = userDto.Username,
                Password = userDto.Password,
                Enabled = userDto.EnabledAddOrEdit
            };
            ResultModel<string> result = new ResultModel<string>();
            if (string.IsNullOrWhiteSpace(userDto.UserId))
            {
                result = await UserService.AddUser(userCreateOrEditDto);
            }
            else
            {
                result = await UserService.EditUser(userCreateOrEditDto);
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

        protected Task DetailClick(UserDto userDto)
        {
            DialogService.Show(new DialogOption()
            {
                Title = "用户明细",
                Size = Size.Large,
                BodyContext = userDto,
                BodyTemplate = builder =>
                {
                    var index = 0;
                    builder.OpenComponent<UserDetail>(index++);
                    builder.SetKey(userDto);
                    builder.CloseComponent();
                }
            });
            return Task.CompletedTask;
        }

        protected Task SetRole(UserDto userDto)
        {
            var option = new DialogOption()
            {
                Title = "配置角色",
                Size = Size.Large,
                BodyContext = userDto
            };
            option.BodyTemplate = DynamicComponent.CreateComponent<UserRole>(new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>(nameof(UserRole.OnClose),new Action(()=>{ option.Dialog?.Toggle(); }))
            }).Render();
            DialogService.Show(option);

            return Task.CompletedTask;
        }

        private IEnumerable<SelectedItem> NullableBoolItems { get; set; } = new SelectedItem[]
        {
            new SelectedItem() { Text = "--全部--", Value = "" },
            new SelectedItem() { Text = "已启用", Value = "true" },
            new SelectedItem() { Text = "已禁用", Value = "false" }
        };
    }
}
