namespace helpMeFest.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Departament { get; set; } // TODO: Verifiy if this field can in Profile table
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile UserProfile { get; set; }
    }
}
