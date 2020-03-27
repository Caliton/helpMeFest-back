using System.ComponentModel.DataAnnotations;

namespace helpMeFest.Models.Models
{
    public class Guest : Person
    {
        public User RelatedUser { get; set; }

        [MaxLength(10)]
        public string Relantionship { get; set; }
    }
}
