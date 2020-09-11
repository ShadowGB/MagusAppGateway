namespace MagusAppGateway.Models.Dtos
{
    public class UserCreateDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool? Enabled { get; set; }
    }
}
