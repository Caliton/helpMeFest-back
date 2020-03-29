using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace helpMeFest.Models.Models
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public int EventOrganizerId { get; set; }
        public User EventOrganizer { get; set; }

        public ICollection<UserEvent> People { get; set; }

        [NotMapped]
        public bool IsParticipating { get; set; }
    }
}
