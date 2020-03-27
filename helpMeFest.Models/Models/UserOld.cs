namespace helpMeFest.Models.Models
{
    public class UserOld
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Departament Departament { get; set; } // TODO: Verifiy if this field can in Profile table
        public Profile UserProfile { get; set; }
    }
}
