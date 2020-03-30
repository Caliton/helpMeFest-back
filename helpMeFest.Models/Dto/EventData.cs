using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace helpMeFest.Models.Dto
{
    public class EventData
    {
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

        public bool IsParticipating { get; set; }

        public int CurrentUserId { get; set; }

        public List<GuestCrud> Guests { get; set; }

        public List<UserCrud> Users { get; set; }
    }

    public class GuestCrud : CrudData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public int RelatedUserId { get; set; }
    }

    public class UserCrud : CrudData
    {
        public int UserId { get; set; }
    }

    public class CrudData
    {
        public EnumCrud EnumCrud { get; set; }
    }

}
