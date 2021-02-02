using BootstrapBlazor.Components;
using IdentityServer4.Models;
using MagusAppGateway.UI.IServices;
using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.Pages.Client
{
    public partial class ClientForm
    {
        [CascadingParameter(Name = "BodyContext")]
        private object param { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        [Parameter]
        public Action OnClose { get; set; }

        [Inject]
        private IApiScopeService ApiScopeService { get; set; }

        [Inject]
        private IClientService ClientService { get; set; }

        private ClientEditDto ClientEditDto { get; set; } = new ClientEditDto();

        private ClientCorsOriginEditDto ClientCorsOriginEditDto { get; set; } = new ClientCorsOriginEditDto();

        private ClientGrantTypeEditDto ClientGrantTypeEditDto { get; set; } = new ClientGrantTypeEditDto();

        //授权流程
        private IEnumerable<SelectedItem> GrantTypes => new List<SelectedItem>
        {
            new SelectedItem ("Implicit", "Implicit"),
            new SelectedItem ("ImplicitAndClientCredentials", "ImplicitAndClientCredentials"),
            new SelectedItem ("Code", "Code"),
            new SelectedItem ("CodeAndClientCredentials", "CodeAndClientCredentials"),
            new SelectedItem ("Hybrid", "Hybrid"),
            new SelectedItem ("HybridAndClientCredentials", "HybridAndClientCredentials"),
            new SelectedItem ("ClientCredentials", "ClientCredentials"),
            new SelectedItem ("ResourceOwnerPassword", "ResourceOwnerPassword"),
            new SelectedItem ("ResourceOwnerPasswordAndClientCredentials", "ResourceOwnerPasswordAndClientCredentials"),
            new SelectedItem ("DeviceFlow", "DeviceFlow")
        };

        //授权类型
        private List<KeyValuePair<string, string[]>> GrantTypeDetail = new List<KeyValuePair<string, string[]>>
        {
            new KeyValuePair<string, string[]>("Implicit",new string[]{ GrantType.Implicit }),
            new KeyValuePair<string, string[]>("ImplicitAndClientCredentials",new string[]{ GrantType.Implicit,GrantType.ClientCredentials }),
            new KeyValuePair<string, string[]>("Code",new string[]{ GrantType.AuthorizationCode }),
            new KeyValuePair<string, string[]>("CodeAndClientCredentials",new string[]{ GrantType.AuthorizationCode,GrantType.ClientCredentials }),
            new KeyValuePair<string, string[]>("Hybrid",new string[]{ GrantType.Hybrid }),
            new KeyValuePair<string, string[]>("HybridAndClientCredentials",new string[]{ GrantType.Hybrid,GrantType.ClientCredentials }),
            new KeyValuePair<string, string[]>("ClientCredentials",new string[]{ GrantType.ClientCredentials }),
            new KeyValuePair<string, string[]>("ResourceOwnerPassword",new string[]{ GrantType.ResourceOwnerPassword }),
            new KeyValuePair<string, string[]>("ResourceOwnerPasswordAndClientCredentials",new string[]{ GrantType.ResourceOwnerPassword,GrantType.ClientCredentials }),
            new KeyValuePair<string, string[]>("DeviceFlow",new string[]{ GrantType.DeviceFlow })
        };


        private ClientPostLogoutRedirectUriEditDto ClientPostLogoutRedirectUriEditDto { get; set; } = new ClientPostLogoutRedirectUriEditDto();

        private ClientRedirectUriEditDto ClientRedirectUriEditDto { get; set; } = new ClientRedirectUriEditDto();

        private ClientScopeEditDto ClientScopeEditDto { get; set; } = new ClientScopeEditDto();

        private List<string> ApiScopes { get; set; } = new List<string>();

        private ClientSecretEditDto ClientSecretEditDto { get; set; } = new ClientSecretEditDto();

        private Task<bool> OnCorsDelete(IEnumerable<ClientCorsOriginEditDto> dtos)
        {
            dtos.ToList().ForEach(x => {
                ClientEditDto.AllowedCorsOrigins.Remove(x);
            });
            return Task.FromResult(true);
        }

        private Task OnCorsAdd()
        {
            ClientEditDto.AllowedCorsOrigins.Add(new ClientCorsOriginEditDto
            {
                Origin = ClientCorsOriginEditDto.Origin
            });
            ClientCorsOriginEditDto.Origin = null;
            return Task.CompletedTask;
        }

        private Task<QueryData<ClientCorsOriginEditDto>> OnCorsQuery(QueryPageOptions options)
        {
            return Task.FromResult(new QueryData<ClientCorsOriginEditDto>
            {
                Items = ClientEditDto.AllowedCorsOrigins,
                TotalCount = ClientEditDto.AllowedCorsOrigins.Count
            });
        }

        private Task<bool> OnGrantDelete(IEnumerable<ClientGrantTypeEditDto> dtos)
        {
            dtos.ToList().ForEach(x => {
                ClientEditDto.AllowedGrantTypes.Remove(x);
            });
            return Task.FromResult(true);
        }

        private Task OnGrantAdd()
        {
            var grantTypes = GrantTypeDetail.FirstOrDefault(x => x.Key == ClientGrantTypeEditDto.GrantType);
            grantTypes.Value.ToList().ForEach(x => {

                if (!ClientEditDto.AllowedGrantTypes.Any(t => t.GrantType == x))
                {
                    ClientEditDto.AllowedGrantTypes.Add(new ClientGrantTypeEditDto
                    {
                        GrantType = x
                    });
                }

            });
            ClientGrantTypeEditDto.GrantType = null;
            return Task.CompletedTask;
        }

        private Task<QueryData<ClientGrantTypeEditDto>> OnGrantQuery(QueryPageOptions options)
        {
            return Task.FromResult(new QueryData<ClientGrantTypeEditDto>
            {
                Items = ClientEditDto.AllowedGrantTypes,
                TotalCount = ClientEditDto.AllowedGrantTypes.Count
            });
        }

        private Task<bool> OnLoginOutDelete(IEnumerable<ClientPostLogoutRedirectUriEditDto> dtos)
        {
            dtos.ToList().ForEach(x => {
                ClientEditDto.PostLogoutRedirectUris.Remove(x);
            });
            return Task.FromResult(true);
        }

        private Task OnLoginOutAdd()
        {
            ClientEditDto.PostLogoutRedirectUris.Add(new ClientPostLogoutRedirectUriEditDto
            {
                PostLogoutRedirectUri = ClientPostLogoutRedirectUriEditDto.PostLogoutRedirectUri
            });
            ClientPostLogoutRedirectUriEditDto.PostLogoutRedirectUri = null;
            return Task.CompletedTask;
        }

        private Task<QueryData<ClientPostLogoutRedirectUriEditDto>> OnLoginOutQuery(QueryPageOptions options)
        {
            return Task.FromResult(new QueryData<ClientPostLogoutRedirectUriEditDto>
            {
                Items = ClientEditDto.PostLogoutRedirectUris,
                TotalCount = ClientEditDto.PostLogoutRedirectUris.Count
            });
        }

        private Task<bool> OnRedirectDelete(IEnumerable<ClientRedirectUriEditDto> dtos)
        {
            dtos.ToList().ForEach(x => {
                ClientEditDto.RedirectUris.Remove(x);
            });
            return Task.FromResult(true);
        }

        private Task OnRedirectAdd()
        {
            ClientEditDto.RedirectUris.Add(new ClientRedirectUriEditDto
            {
                RedirectUri = ClientRedirectUriEditDto.RedirectUri
            });
            ClientRedirectUriEditDto.RedirectUri = null;
            return Task.CompletedTask;
        }

        private Task<QueryData<ClientRedirectUriEditDto>> OnRedirectQuery(QueryPageOptions options)
        {
            return Task.FromResult(new QueryData<ClientRedirectUriEditDto>
            {
                Items = ClientEditDto.RedirectUris,
                TotalCount = ClientEditDto.RedirectUris.Count
            });
        }

        private Task<bool> OnApiDelete(IEnumerable<ClientScopeEditDto> dtos)
        {
            dtos.ToList().ForEach(x => {
                ClientEditDto.AllowedScopes.Remove(x);
            });
            return Task.FromResult(true);
        }

        private Task OnApiAdd()
        {
            if (!ClientEditDto.AllowedScopes.Any(x => x.Scope == ClientScopeEditDto.Scope))
            {
                ClientEditDto.AllowedScopes.Add(new ClientScopeEditDto
                {
                    Scope = ClientScopeEditDto.Scope
                });
            }
            ClientScopeEditDto.Scope = null;
            return Task.CompletedTask;
        }

        private Task<QueryData<ClientScopeEditDto>> OnApiQuery(QueryPageOptions options)
        {
            return Task.FromResult(new QueryData<ClientScopeEditDto>
            {
                Items = ClientEditDto.AllowedScopes,
                TotalCount = ClientEditDto.AllowedScopes.Count
            });
        }

        private Task<bool> OnSecretDelete(IEnumerable<ClientSecretEditDto> dtos)
        {
            dtos.ToList().ForEach(x => {
                ClientEditDto.ClientSecrets.Remove(x);
            });
            return Task.FromResult(true);
        }

        private Task OnSecretAdd()
        {
            ClientEditDto.ClientSecrets.Add(new ClientSecretEditDto
            {
                Value = ClientSecretEditDto.Value,
                Expiration = ClientSecretEditDto.Expiration,
                Description = ClientSecretEditDto.Description
            });
            ClientSecretEditDto.Value = null;
            ClientSecretEditDto.Description = null;
            return Task.CompletedTask;
        }

        private Task<QueryData<ClientSecretEditDto>> OnSecretQuery(QueryPageOptions options)
        {
            return Task.FromResult(new QueryData<ClientSecretEditDto>
            {
                Items = ClientEditDto.ClientSecrets,
                TotalCount = ClientEditDto.ClientSecrets.Count
            });
        }

        protected override async Task OnInitializedAsync()
        {
            if (param != null)
            {
                var model = param as ClientDto;
                var result = await ClientService.GetById(model.Id);
                if (result.status.code == ResultCode.Success)
                {
                    ClientDto clientDto = new ClientDto();
                    clientDto = result.custom;

                    ClientEditDto.Id = clientDto.Id;
                    ClientEditDto.ClientId = clientDto.ClientId;
                    ClientEditDto.ClientName = clientDto.ClientName;
                    ClientEditDto.AccessTokenLifetime = clientDto.AccessTokenLifetime;
                    ClientEditDto.Enabled = clientDto.Enabled;
                    ClientEditDto.RequireClientSecret = clientDto.RequireClientSecret;
                    ClientEditDto.Description = clientDto.Description;


                    clientDto.AllowedCorsOrigins.ForEach(x => {
                        ClientEditDto.AllowedCorsOrigins.Add(new ClientCorsOriginEditDto { Origin = x.Origin });
                    });

                    clientDto.AllowedGrantTypes.ForEach(x => {
                        ClientEditDto.AllowedGrantTypes.Add(new ClientGrantTypeEditDto { GrantType = x.GrantType });
                    });

                    clientDto.AllowedScopes.ForEach(x =>
                    {
                        ClientEditDto.AllowedScopes.Add(new ClientScopeEditDto { Scope = x.Scope });
                    });

                    clientDto.ClientSecrets.ForEach(x => {
                        ClientEditDto.ClientSecrets.Add(new ClientSecretEditDto { Created = x.Created, Description = x.Description, Expiration = x.Expiration.Value, Value = x.Value });
                    });

                    clientDto.PostLogoutRedirectUris.ForEach(x => {
                        ClientEditDto.PostLogoutRedirectUris.Add(new ClientPostLogoutRedirectUriEditDto { PostLogoutRedirectUri = x.PostLogoutRedirectUri });
                    });

                    clientDto.RedirectUris.ForEach(x =>
                    {
                        ClientEditDto.RedirectUris.Add(new ClientRedirectUriEditDto { RedirectUri = x.RedirectUri });
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
            await base.OnInitializedAsync();
            await GetApiScopeAsync();
        }

        private async Task GetApiScopeAsync()
        {
            var list = await ApiScopeService.GetAllApiScope();
            ApiScopes = list.custom.Select(x => x.Name).ToList();
        }

        private async Task OnSave()
        {
            OnClose?.Invoke();
            ResultModel<string> result = new ResultModel<string>();
            if (ClientEditDto.Id == null)
            {
                result = await ClientService.AddClient(ClientEditDto);
            }
            else
            {
                result = await ClientService.EditClient(ClientEditDto);
            }
            if (result.status.code == ResultCode.Success)
            {
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
