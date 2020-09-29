using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientPostLogoutRedirectUriConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientPostLogoutRedirectUriCreateDto> clientPostLogoutRedirectUriCreateDtos { get; set; }
    }
}
