using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Models.Contract.Repositories
{
    public interface IUserRepository
    {
        public User GetUser(string username, string password);
    }
}
