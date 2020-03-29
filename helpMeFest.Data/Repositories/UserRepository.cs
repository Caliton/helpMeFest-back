using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace helpMeFest.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public User CreateFillProps(User user)
        {
            User newUser = user;
            newUser.Profile = this.RepositoryContext.Profile.Find(newUser.Profile.Id);
            newUser.Departament = this.RepositoryContext.Departament.Find(newUser.Departament.Id);
            return this.Create(user);
        }

        public async override Task<IEnumerable<User>> FindByCondition(Expression<Func<User, bool>> expression)
        {
            return await this.RepositoryContext.Set<User>().Where(expression).AsNoTracking().Include(user => user.Profile).Include(user => user.Departament).ToListAsync();
        }

        //public async User GetUserById(int userId)
        //{
            
        //}
    }
}
