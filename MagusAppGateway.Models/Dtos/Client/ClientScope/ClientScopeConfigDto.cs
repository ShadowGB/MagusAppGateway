using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientScopeConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientScopeEditDto> clientScopeEditDtos { get; set; }
    }
}
