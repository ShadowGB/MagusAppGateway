namespace MagusAppGateway.Models.Dtos
{
    public class ClientRedirectUriDto
    {
        public int Id { get; set; }

        public string RedirectUri { get; set; }

        public int ClientId { get; set; }
    }
}
