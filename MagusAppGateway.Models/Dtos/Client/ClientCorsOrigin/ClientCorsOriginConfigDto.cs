using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientCorsOriginConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientCorsOriginCreateDto> clientCorsOriginCreateDtos { get; set; }
    }
}
