using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class OcelotConfigEditDto
    {
        public OcelotConfigEditDto()
        {
            Routes = new List<RoutesEditDto>();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// 配置名称
        /// </summary>
        public string ConfigName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 路由配置
        /// </summary>
        public List<RoutesEditDto> Routes { get; set; }

        /// <summary>
        /// 全局配置
        /// </summary>
        public GlobalConfigurationEditDto GlobalConfiguration { get; set; }
    }
}
