using helpMeFest.Models.Models;
using helpMeFest.Models.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<AuthenticationResult> ValidateLogin(string email, string password);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
