using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.ViewModel
{
    public class UserCreateOrEditDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool Enabled { get; set; }
    }
}
