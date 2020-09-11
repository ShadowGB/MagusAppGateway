using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.Models
{
    public class Users : BaseModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Enabled { get; set; }
    }
}
