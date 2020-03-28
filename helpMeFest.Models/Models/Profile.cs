using System.ComponentModel.DataAnnotations;

namespace helpMeFest.Models.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}