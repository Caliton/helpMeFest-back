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

        public async Task<IEnumerable<Event>> FindAllByUser(int userId)
        {
            return await this.GetAllEventsFromUser(userId).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<Event>> FindAllByOwner(int ownerId)
        {
            return await this.RepositoryContext.Event.Where(x => x.EventOrganizerId == ownerId)
                .Select(ev => new Event()
                {
                    Id = ev.Id,
                    DateEnd = ev.DateEnd,
                    DateInitial = ev.DateInitial,
                    Description = ev.Description,
                    EventOrganizerId = ev.EventOrganizerId,
                    IsParticipating = true,
                    Name = ev.Name,
                    Place = ev.Place,
                }).ToListAsync();
        }

        public async Task<Event> FindEventByIdAndUser(int eventId, int userId)
        {
            var eventsByUser = this.GetAllEventsFromUser(userId);
            var returnedEvent = await eventsByUser.Where(x => x.Id == eventId).FirstOrDefaultAsync();
            returnedEvent.Guests = await this.GetGuestsEvent(eventId).Where(x => x.RelatedUserId == userId).ToListAsync();
            return returnedEvent;
        }

        private IQueryable<Event> GetAllEventsFromUser(int userId)
        {
            return from ev in this.RepositoryContext.Event
                   join uv in this.RepositoryContext.UserEvent on userId equals uv.PersonId into result
                   from data in result.DefaultIfEmpty()
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

        private IQueryable<Guest> GetGuestsEvent(int eventId)
        {
            return from guests in this.RepositoryContext.Guests
                   join userEvent in this.RepositoryContext.UserEvent on guests.Id equals userEvent.PersonId
                   where userEvent.EventId == eventId
                   select guests;
        }
    }
}
