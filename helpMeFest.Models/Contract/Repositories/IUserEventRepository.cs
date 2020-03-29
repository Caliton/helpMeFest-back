using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.Repositories
{
    public interface IUserEventRepository : IRepositoryBase<UserEvent>
    {
        public void DeleteMany(List<UserEvent> events);
    }
}
