using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpMeFest.Api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public int ProfileId { get; set; }
        public int DepartamentId { get; set; }
    }
}
