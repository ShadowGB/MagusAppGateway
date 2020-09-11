namespace MagusAppGateway.Models.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool? Enabled { get; set; }
    }
}
