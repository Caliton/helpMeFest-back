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
        private readonly IEventRepository eventRepository;
        private readonly IUserEventRepository userEventRepository;

        public UnitOfWork(DatabaseContext repositoryContext)
        {
            databaseContext = repositoryContext;
        }

        public IUserRepository UserRepository => this.userRepository ?? new UserRepository(databaseContext);

        public IProfileRepository ProfileRepository => this.profileRepository ?? new ProfileRepository(databaseContext);

        public IDepartamentRepository DepartamentRepository => this.departamentRepository ??new DepartamentRepository(databaseContext);

        public IEventRepository EventRepository => this.eventRepository ?? new EventRepository(databaseContext);

        public IUserEventRepository UserEventRepository => this.userEventRepository ?? new UserEventRepository(databaseContext);

        public async Task<int> Commit()
        {
            return await this.databaseContext.SaveChangesAsync();
        }
    }
}
