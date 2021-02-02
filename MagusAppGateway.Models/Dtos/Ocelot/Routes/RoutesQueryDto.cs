using System;
using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class RoutesQueryDto : QueryModelBase
    {
        public Guid OcelotConfigId { get; set; }

        /// <summary>
        /// 下游路径模板
        /// </summary>
        public string DownstreamPathTemplate { get; set; }

        /// <summary>
        /// 下游协议
        /// </summary>
        public string DownstreamScheme { get; set; }

        /// <summary>
        /// 上游路径模板
        /// </summary>
        public string UpstreamPathTemplate { get; set; }

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        public bool? RouteIsCaseSensitive { get; set; }
    }
}
