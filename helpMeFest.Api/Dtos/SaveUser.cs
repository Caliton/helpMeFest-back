using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpMeFest.Api.Dtos
{
    public class SaveUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsGuest { get; set; }
        public int ProfileId { get; set; }
        public int DepartamentId { get; set; }
    }
}
