using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;

namespace MagusAppGateway.Gateway.Extensions
{
    public static class AddPostgreSQLOcelot
    {
        /// <summary>
        /// 添加默认的注入方式，所有需要传入的参数都是用默认值
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IOcelotBuilder AddOcelotDbConfig(this IOcelotBuilder builder, Action<OcelotDbConfiguration> option)
        {
            builder.Services.Configure(option);
            //配置信息
            builder.Services.AddSingleton(
                resolver => resolver.GetRequiredService<IOptions<OcelotDbConfiguration>>().Value);
            //配置文件仓储注入
            builder.Services.AddSingleton<IFileConfigurationRepository, PostgreSQLFileConfigurationRepository>();
            return builder;
        }
    }
}

