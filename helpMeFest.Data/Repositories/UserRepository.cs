using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace helpMeFest.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(string username, string password)
        {
            var users = new List<User>
            {
                new User() { Id = 1, Name = "admin", Departament = "Development", Email = "email@email.com", Password = "12345", UserProfile = new Profile() { Id = 1, Description = "Profile 1" } },
                new User() { Id = 2, Name = "admin2", Departament = "Analysis", Email = "email@email.com", Password = "12345", UserProfile = new Profile() { Id = 2, Description = "Profile 2" } }
            };

            return users.Where(x => x.Email.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).FirstOrDefault();
        }
    }
}
