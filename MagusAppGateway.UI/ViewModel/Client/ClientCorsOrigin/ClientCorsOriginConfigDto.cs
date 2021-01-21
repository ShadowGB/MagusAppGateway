using System.Collections.Generic;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientCorsOriginConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientCorsOriginEditDto> clientCorsOriginCreateDtos { get; set; }
    }
}
