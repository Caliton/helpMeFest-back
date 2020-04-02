using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.Repositories
{
    public interface IUserEventRepository : IRepositoryBase<UserEvent>
    {
        void RemoveGuestByUser(int eventId, int userId);
    }
}
