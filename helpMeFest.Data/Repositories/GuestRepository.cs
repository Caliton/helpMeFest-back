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
            //var returnedList = new List<Guest>();
            //foreach (var item in guests)
            //{
            //    var createdGuest = this.RepositoryContext.Add(item);
            //    await this.RepositoryContext.SaveChangesAsync();
            //}
            await this.RepositoryContext.AddRangeAsync(guests);
            return null;
        }
    }
}
