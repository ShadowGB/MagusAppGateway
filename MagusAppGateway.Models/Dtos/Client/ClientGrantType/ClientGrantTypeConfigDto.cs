using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientGrantTypeConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientGrantTypeEditDto> clientGrantTypeEditDtos { get; set; }
    }
}
