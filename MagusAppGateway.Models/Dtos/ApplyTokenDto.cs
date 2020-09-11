using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class ApplyTokenDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ClientId { get; set; }

        public string ClientSerect { get; set; }
    }
}
