using System;

namespace MagusAppGateway.Models.Dtos
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool? Enabled { get; set; }
    }
}
