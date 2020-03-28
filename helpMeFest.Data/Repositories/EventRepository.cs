using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Data.Repositories
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository 
    {
        public EventRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }

        public Event CreateDetachedChild(Event entity)
        {
            //this.RepositoryContext.Entry(entity.EventOrganizer).State = EntityState.Detached;
            var added = this.RepositoryContext.Set<Event>().Add(entity).Entity;
            this.RepositoryContext.Entry(entity.EventOrganizer.Profile).State = EntityState.Unchanged;
            this.RepositoryContext.Entry(entity.EventOrganizer.Departament).State = EntityState.Unchanged;
            return added;


        }
    }
}
