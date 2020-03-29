using helpMeFest.Models;
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
            var created = this.unitOfWork.EventRepository.Create(ev);
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

        public async Task<Event> GetEventById(int eventId, int userId)
        {
            return await this.unitOfWork.EventRepository.FindEventByIdAndUser(eventId, userId);
        }

        public async Task<Event> UpdateEvent(Event ev)
        {
            // PEGAR O USUÁRIO
            // VERIFICAR PERFIL
            // SE FOR ORGANIZADOR
            // APAGAR TUDO E CRIAR DE NOVO (EVENT E USEREVENT) PORQUE ELE PODE EDITAR TANDO O CABEÇALHO, QUANTO OS PARTICIPANTES
            // SE UM USUÁRIO COMUM
            // APAGA TODOS OS REGISTRO DA USEREVENT E INSERE OS QUE CHEGAREM DA REQUISIÇÃO 

            //var events = await this.unitOfWork.EventRepository.FindByCondition(x => x.Id == ev.Id);
            var data = await this.unitOfWork.UserRepository.FindByCondition(x => x.Id == ev.Id);
            var user = data.FirstOrDefault();

            if (user != null)
            {
                var alreadyExists = this.unitOfWork.EventRepository.Exists(x => x.Id == ev.Id);

                if (alreadyExists)
                {
                    if ((EnumProfile)user.ProfileId == EnumProfile.ORGANIZER)
                    {
                        this.UpdateEventHeader(ev);
                    }

                    List<UserEvent> userEvents = ev.People.Select(x => new UserEvent() { EventId = ev.Id, PersonId = x.PersonId}).ToList();
                    this.unitOfWork.UserEventRepository.DeleteMany(userEvents);

                    await this.unitOfWork.Commit();
                    return ev;
                }
            }

            return null;
        }

        public void UpdateEventHeader(Event ev)
        {
            Event eventHeader = ev;
            eventHeader.People = null;
            this.unitOfWork.EventRepository.Update(eventHeader);
        }
    }
}
