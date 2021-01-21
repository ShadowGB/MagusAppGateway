using System.Collections.Generic;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientGrantTypeConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientGrantTypeEditDto> clientGrantTypeCreateDtos { get; set; }
    }
}
