using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class DtoBase
    {
        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }
    }
}
