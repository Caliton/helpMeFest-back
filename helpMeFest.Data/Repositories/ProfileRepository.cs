using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Data.Repositories
{
    public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
