using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class OcelotConfigQueryDto : QueryModelBase
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsEnable { get; set; }

        /// <summary>
        /// 配置名称
        /// </summary>
        public string ConfigName { get; set; }

        /// <summary>
        /// 全局配置
        /// </summary>
        public GlobalConfigurationDto GlobalConfiguration { get; set; }
    }
}
