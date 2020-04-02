using helpMeFest.Models;
using helpMeFest.Models.Contract.Services;
using helpMeFest.Models.Contract.UnitOfWork;
using helpMeFest.Models.Dto;
using helpMeFest.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpMeFest.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Event> CreateEvent(Event ev)
        {
            var created = this.unitOfWork.EventRepository.Create(ev);
            await this.unitOfWork.Commit();
            this.unitOfWork.UserEventRepository.Create(new UserEvent { EventId = created.Id, PersonId = created.EventOrganizerId });
            await this.unitOfWork.Commit();
            return created;
        }

        public async Task<IEnumerable<Event>> FindAllByUser(int userId)
        {
            return await this.unitOfWork.EventRepository.FindAllByUser(userId);
        }

        public async Task<Event> DeleteEvent(int Id) //TODO: Verificar se da para alterar o retorno
        {
            var events = await this.unitOfWork.EventRepository.FindByCondition(x => x.Id == Id);
            var eventModel = events.FirstOrDefault();

            if (eventModel != null)
            {
                this.unitOfWork.EventRepository.Delete(eventModel);
                await this.unitOfWork.Commit();
                return eventModel;
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Event>> GetAllEvents()
        {
            return this.unitOfWork.EventRepository.FindAll();
        }

        public async Task<EventDetailDto> GetEventById(int eventId, int userId)
        {
            return await this.unitOfWork.EventRepository.FindEventByIdAndUser(eventId, userId);
        }

        public async Task<IEnumerable<Event>> GetEventsByOwner(int onwerId)
        {
            return await this.unitOfWork.EventRepository.FindAllByOwner(onwerId);
        }

        public async Task<EventDetailDto> UpdateEvent(int id, EventDetailDto ev)
        {
            var data = await this.unitOfWork.UserRepository.FindByCondition(x => x.Id == ev.CurrentUserId);
            var user = data.FirstOrDefault();
            var userAlreadySubscripted = this.unitOfWork.UserEventRepository.Exists(x => x.EventId == id && x.PersonId == ev.CurrentUserId);

            if (!userAlreadySubscripted)
            {
                this.unitOfWork.UserEventRepository.Create(new UserEvent { EventId = id, PersonId = ev.CurrentUserId});
                await this.unitOfWork.Commit();
            }

            if (user != null)
            {
                var alreadyExists = this.unitOfWork.EventRepository.Exists(x => x.Id == id);

                if (alreadyExists)
                {
                    if ((EnumProfile)user.ProfileId == EnumProfile.ORGANIZER || ev.EventOrganizerId == ev.CurrentUserId)
                    {
                        this.UpdateEventHeader(id, ev);
                        this.HandleUserChanges(id, ev);
                    }

                    if (ev.Guests != null)
                    {

                        var newGuests = ev.Guests.Where(x => x.EnumCrud == EnumCrud.CREATED)
                            .Select(x => new Guest() { IsGuest = true, Name = x.Name, RelatedUserId = x.RelatedUserId, Relantionship = x.Relationship, Events = new List<UserEvent>() { new UserEvent { EventId = id } } }).ToList();

                        if (newGuests.Count > 0)
                        {
                            await this.unitOfWork.GuestRepository.AddRange(newGuests);
                            await this.unitOfWork.Commit();
                        }

                        var updatedGuests = ev.Guests.Where(x => x.EnumCrud == EnumCrud.UPDATED).Select(guest => new Guest() { Id = guest.Id, IsGuest = true, Name = guest.Name, RelatedUserId = guest.RelatedUserId, Relantionship = guest.Relationship, Events = null }).ToList();

                        if (updatedGuests.Count > 0)
                        {
                            this.unitOfWork.GuestRepository.UpdateRange(updatedGuests);
                            await this.unitOfWork.Commit();
                        }

                        var deletedGuests = ev.Guests.Where(x => x.EnumCrud == EnumCrud.DELETED).Select(guest => new Guest() { Id = guest.Id, IsGuest = true, Name = guest.Name, RelatedUserId = guest.RelatedUserId, Relantionship = guest.Relationship, Events = null }).ToList();

                        if (deletedGuests.Count > 0)
                        {
                            this.unitOfWork.GuestRepository.DeleteRange(deletedGuests);
                            await this.unitOfWork.Commit();
                        }
                    }

                    await this.unitOfWork.Commit();
                    return await this.GetEventById(id, ev.CurrentUserId);
                }
            }

            return null;
        }

        public void UpdateEventHeader(int id, EventDetailDto ev)
        {
            Event eventHeader = new Event()
            {
                Id = id,
                Name = ev.Name,
                DateEnd = ev.DateEnd,
                DateInitial = ev.DateInitial,
                Description = ev.Description,
                EventOrganizerId = ev.EventOrganizerId,
                People = null,
                Place = ev.Place,
                Guests = null
            };

            this.unitOfWork.EventRepository.Update(eventHeader);
        }

        private void HandleUserChanges(int eventId, EventDetailDto eventData)
        {
            if (eventData.Users == null)
            {
                return;
            } 

            var removedUsers = eventData.Users.Where(x => x.EnumCrud == EnumCrud.DELETED).ToList();
            if (removedUsers.Count > 0)
            {
                foreach (var item in removedUsers)
                {
                    this.unitOfWork.UserEventRepository.RemoveGuestByUser(eventId, item.UserId);
                    eventData.Guests.RemoveAll(x => x.RelatedUserId == item.UserId);

                    this.unitOfWork.UserEventRepository.Delete(new UserEvent() { EventId = eventId, PersonId = item.UserId });
                    eventData.Users.Remove(item);
                }
            }

        }
    }
}
