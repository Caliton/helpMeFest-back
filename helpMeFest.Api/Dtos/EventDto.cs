using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace helpMeFest.Api.Dtos
{
    public class EventDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateInitial { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(45)]
        public string Place { get; set; }

        public int EventOrganizerId { get; set; }
    }
}
