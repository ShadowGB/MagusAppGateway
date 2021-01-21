using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;

namespace MagusAppGateway.UI
{
    public class CustomAuthorizationMessageHandler:AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                //这是Web Api的根地址
                authorizedUrls: new[] { "http://127.0.0.1:5001" },
                //对应Api Scope, 表示请求上面的Web Api之前需要先获取该Scope对应的Access Token，并附在Http头里面
                scopes: new[] { "config" });
        }
    }
}
