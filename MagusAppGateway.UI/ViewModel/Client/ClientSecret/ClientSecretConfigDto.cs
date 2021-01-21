using System;
using System.Collections.Generic;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientSecretConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientSecretEditDto> clientSecretCreateDtos { get; set; }
    }
}
