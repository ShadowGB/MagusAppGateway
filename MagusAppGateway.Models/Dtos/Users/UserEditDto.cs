using System;

namespace MagusAppGateway.Models.Dtos
{
    public class UserEditDto
    {
        public Guid? UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool? Enabled { get; set; }
    }
}
