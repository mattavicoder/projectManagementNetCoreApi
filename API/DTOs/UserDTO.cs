using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDTO
    {
        public string DisplayName { get; set; }

        public string Token { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }
    }
}