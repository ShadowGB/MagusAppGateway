using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MagusAppGateway.UI.ViewModel
{
    public class OcelotConfigDto
    {
        public OcelotConfigDto()
        {
            Routes = new List<RoutesDto>();
        }

        [Display(Name ="编号")]
        public Guid? Id { get; set; }

        /// <summary>
        /// 配置名称
        /// </summary>
        [Display(Name = "配置名称")]
        public string ConfigName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public bool? IsEnable { get; set; }

        /// <summary>
        /// 路由配置
        /// </summary>
        public List<RoutesDto> Routes { get; set; }

        /// <summary>
        /// 全局配置
        /// </summary>
        public GlobalConfigurationDto GlobalConfiguration { get; set; }
    }
}
