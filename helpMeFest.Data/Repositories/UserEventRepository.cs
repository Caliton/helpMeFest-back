using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Data.Repositories
{
    public class UserEventRepository : RepositoryBase<UserEvent>, IUserEventRepository
    {
        public UserEventRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }

        public void DeleteMany(List<UserEvent> events)
        {
            this.RepositoryContext.Set<UserEvent>().RemoveRange(events);
        }

        public void CreateMany(List<UserEvent> userEvents)
        {
            this.RepositoryContext.Set<UserEvent>().AddRange(userEvents);
        }

        public void RemoveGuestByUser(int eventId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
