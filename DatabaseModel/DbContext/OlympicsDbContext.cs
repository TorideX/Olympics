using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class OlympicsDbContext : DbContext
    {
        public OlympicsDbContext() : base("name=LocalDB")
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var country = modelBuilder.Entity<Country>();
            country.HasKey(c => c.Id)
                .Property(c=>c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            country.Property(c => c.Name).IsRequired().HasMaxLength(200);
            country.Property(c => c.ImagePath);

            var evnt = modelBuilder.Entity<Event>();
            evnt.HasKey(e => e.Id)
                .Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            evnt.HasMany(e => e.Participants);

            var medal = modelBuilder.Entity<MedalSportsman>();
            medal.HasKey(m => m.Id)
                .Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            medal.Property(m => m.MedalType).IsRequired();
            
            var olymp = modelBuilder.Entity<Olympiad>();
            olymp.HasKey(o => o.Id)
                .Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            olymp.Property(o => o.City).IsRequired().HasMaxLength(200);
            olymp.Property(o => o.Year).IsRequired();
            olymp.Property(o => o.Season).IsRequired();
            olymp.Property(o => o.ImagePath);

            var sportsman = modelBuilder.Entity<Sportsman>();
            sportsman.HasKey(s => s.Id)
                .Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            sportsman.Property(s => s.FirstName).IsRequired().HasMaxLength(200);
            sportsman.Property(s => s.LastName).IsRequired().HasMaxLength(200);
            sportsman.Property(s => s.BirthDate).IsRequired();

            var participant = modelBuilder.Entity<Participant>();
            participant.HasKey(p => p.Id) 
                .Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            participant.HasMany(p => p.Sportsmen);
            participant.HasMany(p => p.Medals);

            var sport = modelBuilder.Entity<Sport>();
            sport.HasKey(s => s.Id)
                .Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            sport.Property(s => s.Name).IsRequired().HasMaxLength(200);
            sport.Property(s => s.Season).IsRequired();
            sport.Property(s => s.Description);
        }

        public DbSet<Sport> Sports { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Olympiad> Olympiads { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Sportsman> Sportsmen { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
