using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace helpMeFest.Data.Repositories
{
    public class GuestRepository : RepositoryBase<Guest>, IGuestRepository
    {
        public GuestRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Guest>> AddRange(IEnumerable<Guest> guests)
        {
            await this.RepositoryContext.AddRangeAsync(guests);
            return null;
        }

        public void DeleteRange(List<Guest> deletedGuest) // Implementar validação para verificar se o convidado existe no banco
        {
            //this.RepositoryContext.);
            this.RepositoryContext.Guests.RemoveRange(deletedGuest);
        }

        public void UpdateRange(List<Guest> updatedGuests)
        {
          this.RepositoryContext.Guests.UpdateRange(updatedGuests);

        }
    }
}
