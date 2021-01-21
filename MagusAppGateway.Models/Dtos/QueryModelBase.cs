using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class QueryModelBase
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
    }
}
