using helpMeFest.Models.Models;

namespace helpMeFest.Models.Contract.Repositories
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        public Event CreateDetachedChild(Event entity);
    }
}