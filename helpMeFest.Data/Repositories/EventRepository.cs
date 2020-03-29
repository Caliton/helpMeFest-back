using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Data.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository 
    {
        public EventRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }

        public Event CreateDetachedChild(Event entity)
        {
            var added = this.RepositoryContext.Set<Event>().Add(entity).Entity;
            this.RepositoryContext.Entry(entity.EventOrganizer.Profile).State = EntityState.Unchanged;
            this.RepositoryContext.Entry(entity.EventOrganizer.Departament).State = EntityState.Unchanged;
            return added;
        }

        public async Task<IEnumerable<Event>> FindAllByUser(int userId)
        {
            return await this.GetAllEventsFromUser(userId).ToListAsync();
        }
        
        public async Task<Event> FindEventByIdAndUser(int eventId, int userId)
        {
            var eventsByUser = this.GetAllEventsFromUser(userId);
            return await eventsByUser.Where(x => x.Id == eventId).Include(ev => ev.People);
        }

        private IQueryable<Event> GetAllEventsFromUser(int userId)
        {
            return from ev in this.RepositoryContext.Event
                   join uv in this.RepositoryContext.UserEvent on userId equals uv.EventId into result
                   from data in result
                   select new Event()
                   {
                       Id = ev.Id,
                       DateEnd = ev.DateEnd,
                       DateInitial = ev.DateInitial,
                       Description = ev.Description,
                       EventOrganizerId = ev.EventOrganizerId,
                       IsParticipating = data.EventId != ev.Id ? false : true,
                       Name = ev.Name,
                       Place = ev.Place,
                   };
        }
    }
}
