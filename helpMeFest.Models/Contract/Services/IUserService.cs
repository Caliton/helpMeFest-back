using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        User ValidateLogin(string email, string password);
    }
}
