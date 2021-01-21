using System.Collections.Generic;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientRedirectUriConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientRedirectUriEditDto> clientRedirectUriCreateDtos { get; set; }
    }
}
