using System;

namespace MagusAppGateway.UI.ViewModel
{
    public class ClientSecretEditDto
    {
        public string Description { get; set; }

        public string Value { get; set; }

        public DateTime? Expiration { get; set; }

        public DateTime Created { get; set; }
    }
}
