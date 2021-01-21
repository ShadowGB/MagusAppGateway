using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientQueryDto: QueryModelBase
    {

        [Display(Name ="是否启用")]
        public bool? Enabled { get; set; } = true;

        [Display(Name ="客户端编号")]
        public string ClientId { get; set; }

        [Display(Name ="是否需要客户端秘钥")]
        public bool? RequireClientSecret { get; set; } = true;

        [Display(Name ="客户端名称")]
        public string ClientName { get; set; }

        [Display(Name ="描述")]
        public string Description { get; set; }

        public DateTime? CreatedStart { get; set; }

        public DateTime? CreatedEnd { get; set; }

        public DateTime? UpdatedStart { get; set; }

        public DateTime? UpdatedEnd { get; set; }
    }
}
