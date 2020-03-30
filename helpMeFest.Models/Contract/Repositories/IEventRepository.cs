using helpMeFest.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.Repositories
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        public Task<IEnumerable<Event>> FindAllByUser(int userId);
        public Task<Event> FindEventByIdAndUser(int eventId, int userId);

        public Task<IEnumerable<Event>> FindAllByOwner(int ownerId);

    }
}