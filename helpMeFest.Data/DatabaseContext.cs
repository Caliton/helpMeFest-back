﻿using helpMeFest.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Departament> Departament { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Profile> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<UserEvent>().HasKey(sc => new { sc.IdUser, sc.IdEvent });
            modelBuider.Entity<Person>().ToTable("Person");
            base.OnModelCreating(modelBuider);
        }
    
    }
}
