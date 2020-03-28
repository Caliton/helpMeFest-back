using helpMeFest.Models.Contract.Services;
using helpMeFest.Models.Contract.UnitOfWork;
using helpMeFest.Models.Models;
using System;
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
            //var loadOrganizer = await this.unitOfWork.UserRepository.FindByCondition(x => x.Id == ev.EventOrganizer.Id);
            //ev.EventOrganizer = loadOrganizer.FirstOrDefault();
            var created = this.unitOfWork.EventRepository.Create(ev);
            await this.unitOfWork.Commit();
            return created;
        }

        public async Task<Event> DeleteEvent(int Id) //TODO: Verificar se da para alterar o retorno
        {
            var events  = await this.unitOfWork.EventRepository.FindByCondition(x=> x.Id == Id);
            var eventModel = events.FirstOrDefault();

            if(eventModel != null)
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

        public async Task<Event> GetEventById(int enventId)
        {
            var events = await this.unitOfWork.EventRepository.FindByCondition(x => x.Id == enventId);
            return events.FirstOrDefault();
        }

        public async Task<Event> UpdateEvent(Event ev)
        {
            var events = await this.unitOfWork.EventRepository.FindByCondition(x => x.Id == ev.Id);
            var eventModel = events.FirstOrDefault();

            if (eventModel != null)
            {
                this.unitOfWork.EventRepository.Update(eventModel);
                await this.unitOfWork.Commit();
                return eventModel;
            }
            else
            {
                return null;
            }
        }
    }
}
