using System;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientSecretUpdateDto
    {
        public string Description { get; set; }

        public string Value { get; set; }

        public DateTime? Expiration { get; set; }

        public DateTime Created { get; set; }
    }
}
