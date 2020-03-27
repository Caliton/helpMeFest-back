using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace helpMeFest.Models.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateInitial { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(45)]
        public string Place { get; set; }
        public User EventOrganizer { get; set; }
    }
}
