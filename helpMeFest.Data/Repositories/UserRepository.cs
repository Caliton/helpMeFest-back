using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public override IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression)
        {
            return this.RepositoryContext.Set<User>().Where(expression).AsNoTracking().Include(user => user.Profile).Include(user => user.Departament).AsNoTracking();
        }
    }
}
