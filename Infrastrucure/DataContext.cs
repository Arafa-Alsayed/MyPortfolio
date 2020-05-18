
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastrucure
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Core.Entities.Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Core.Entities.PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Core.Entities.Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    Avatar = "MyAvatar.jpg",
                    FullName = "Arafa Alsayed",
                    Profil = "Web developer"
                }
                );
        }

        public DbSet<Owner> Owner { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
    }
}
