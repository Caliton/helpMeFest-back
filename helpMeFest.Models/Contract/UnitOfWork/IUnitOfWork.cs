using helpMeFest.Models.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProfileRepository ProfileRepository { get; }
        IDepartamentRepository DepartamentRepository { get;}
        IEventRepository EventRepository { get; }

        Task<int> Commit();
    }
}
