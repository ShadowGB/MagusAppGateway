using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientScopeConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientScopeCreateDto> clientScopeCreateDtos { get; set; }
    }
}
