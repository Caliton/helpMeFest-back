using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace helpMeFest.Api.Dtos
{
    public class SaveUserEvent
    {
        [Required]
        public int IdEvent { get; set; }

        [Required]
        public List<int> Persons { get; set; }
    }
}
