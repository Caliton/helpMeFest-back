using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Models.Contract.Repositories
{
    public interface IGuestRepository : IRepositoryBase<Guest>
    {
        Task<IEnumerable<Guest>> AddRange(IEnumerable<Guest> guests);
        void UpdateRange(List<Guest> updatedGuests);

        void DeleteRange(List<Guest> deletedGuest);
    }
}
