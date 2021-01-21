using System.Collections.Generic;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientScopeConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientScopeEditDto> clientScopeCreateDtos { get; set; }
    }
}
