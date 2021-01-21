using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ApiScopeDto : QueryModelBase
    {
        public ApiScopeDto()
        {
            UserClaims = new List<ApiScopeClaimDto>();
            Properties = new List<ApiScopePropertyDto>();
        }

        [Display(Name = "编号")]
        public int? Id { get; set; }

        [Display(Name = "是否启用")]
        public bool Enabled { get; set; }

        [Display(Name = "API名称")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "显示名称")]
        public string DisplayName { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "是否必须")]
        public bool Required { get; set; } = false;

        [Display(Name = "是否高亮显示")]
        public bool Emphasize { get; set; } = false;

        [Display(Name = "是否显示在发现文档")]
        public bool ShowInDiscoveryDocument { get; set; } = true;

        public List<ApiScopeClaimDto> UserClaims { get; set; }

        public List<ApiScopePropertyDto> Properties { get; set; }
    }
}
