using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.Services
{
    public interface IUserEventService
    {
        Task<int> LeaveEvent(int eventId, int userId);
    }
}
