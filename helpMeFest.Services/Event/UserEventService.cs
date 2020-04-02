using helpMeFest.Models.Contract.Services;
using helpMeFest.Models.Contract.UnitOfWork;
using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Services.Events
{
    public class UserEventService : IUserEventService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserEventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> LeaveEvent(int eventId, int userId)
        {
            this.unitOfWork.UserEventRepository.RemoveGuestByUser(eventId, userId);

            var result = await this.unitOfWork.UserEventRepository.FindByCondition(x => x.EventId == eventId && x.PersonId == userId);

            this.unitOfWork.UserEventRepository.Delete(result.FirstOrDefault());

            return await this.unitOfWork.Commit();
        }
    }
}
