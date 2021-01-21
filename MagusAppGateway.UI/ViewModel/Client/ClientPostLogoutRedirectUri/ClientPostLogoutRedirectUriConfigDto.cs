using System.Collections.Generic;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientPostLogoutRedirectUriConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientPostLogoutRedirectUriEditDto> clientPostLogoutRedirectUriCreateDtos { get; set; }
    }
}
