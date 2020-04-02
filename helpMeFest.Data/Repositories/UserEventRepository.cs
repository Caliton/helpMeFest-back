using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace helpMeFest.Data.Repositories
{
    public class UserEventRepository : RepositoryBase<UserEvent>, IUserEventRepository
    {
        public UserEventRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMany(List<UserEvent> userEvents)
        {
            this.RepositoryContext.Set<UserEvent>().AddRange(userEvents);
        }

        public void RemoveGuestByUser(int eventId, int userId)
        {
            var guestUser = this.RepositoryContext.Guests.Where(x => x.RelatedUserId == userId).ToList();
            if (guestUser.Count > 0)
            {
                this.RepositoryContext.Guests.RemoveRange(guestUser);
            }
        }
    }
}
