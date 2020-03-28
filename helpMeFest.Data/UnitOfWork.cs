using helpMeFest.Data.Repositories;
using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Contract.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext databaseContext;

        private readonly IUserRepository userRepository;
        private readonly IDepartamentRepository departamentRepository;
        private readonly IProfileRepository profileRepository;

        public UnitOfWork(DatabaseContext repositoryContext)
        {
            databaseContext = repositoryContext;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository ?? new UserRepository(databaseContext);
            }
        }

        public IProfileRepository ProfileRepository => this.profileRepository ?? new ProfileRepository(databaseContext);

        public IDepartamentRepository DepartamentRepository => this.departamentRepository ??new DepartamentRepository(databaseContext);

        public Task<int> Commit()
        {
            return this.databaseContext.SaveChangesAsync();
        }
    }
}
