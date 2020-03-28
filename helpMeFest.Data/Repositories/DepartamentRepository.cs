using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Data.Repositories
{
    public class DepartamentRepository : RepositoryBase<Departament>, IDepartamentRepository
    {
        public DepartamentRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
