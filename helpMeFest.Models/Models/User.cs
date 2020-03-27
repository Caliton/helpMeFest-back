using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace helpMeFest.Models.Models
{
    public class User : Person
    {
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(25)]
        public string Password { get; set; }

        public Profile Profile { get; set; }

        public Departament Departament { get; set; }
    }
}
