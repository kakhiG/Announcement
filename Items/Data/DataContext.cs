using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.MobileNumber).IsRequired();
            });

            modelBuilder.Entity<Announcement>().HasData(
                new Announcement() { Id = 1, Title = "Mobile Phone ", Description = "good camera nokia phone", MobileNumber = "9919291" },
                new Announcement() { Id = 2, Title = "Car ", Description = "new audi car ", MobileNumber = "121212" },
                new Announcement() { Id = 3, Title = "Game Console", Description = "new xbox ", MobileNumber = "121212" },
                new Announcement() { Id = 4, Title = "Antique", Description = "19th century table ", MobileNumber = "121212" },
                new Announcement() { Id = 5, Title = "New House", Description = "4 floor house in village ", MobileNumber = "121212" },
                new Announcement() { Id = 6, Title = "Car Selling", Description = "new mercedes-benz car ", MobileNumber = "121212" });
        }

        public DbSet<Announcement> Announcements { get; set; }
    }
}

