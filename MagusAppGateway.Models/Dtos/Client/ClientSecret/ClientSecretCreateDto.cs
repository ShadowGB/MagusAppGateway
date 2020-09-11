using System;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientSecretCreateDto
    {
        public string Description { get; set; }

        public string Value { get; set; }

        public DateTime? Expiration { get; set; }

        public DateTime Created { get; set; }
    }
}
