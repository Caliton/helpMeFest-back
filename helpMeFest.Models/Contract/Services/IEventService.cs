using helpMeFest.Models.Dto;
using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event> CreateEvent(Event ev);
        Task<EventDetailDto> GetEventById(int enventId, int userId);
        Task<EventDetailDto> UpdateEvent(int Id, EventDetailDto ev);
        Task<Event> DeleteEvent(int enventId);
        Task<IEnumerable<Event>> FindAllByUser(int userId);
        public Task<IEnumerable<Event>> GetEventsByOwner(int onwerId);
    }
}
