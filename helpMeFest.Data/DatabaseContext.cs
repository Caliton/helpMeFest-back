using helpMeFest.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlConnector.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        }

        public DbSet<Departament> Departament { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Profile> Profile { get; set; }

        public DbSet<UserEvent> UserEvent { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEvent>().HasKey(sc => new { sc.PersonId, sc.EventId });
            modelBuilder.Entity<UserEvent>()
                .HasOne(usev => usev.Person)
                .WithMany(p => p.Events)
                .HasForeignKey(usev => usev.PersonId);

            modelBuilder.Entity<UserEvent>()
                    .HasOne(usev => usev.Event)
                    .WithMany(e => e.People)
                    .HasForeignKey(usev => usev.EventId);
            
            modelBuilder.Entity<Person>().ToTable("Person");

            base.OnModelCreating(modelBuilder);
        }
    }
}
