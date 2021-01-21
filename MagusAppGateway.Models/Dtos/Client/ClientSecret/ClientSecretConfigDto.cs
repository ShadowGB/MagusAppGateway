using System;
using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientSecretConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientSecretEditDto> clientSecretEditDtos { get; set; }
    }
}
