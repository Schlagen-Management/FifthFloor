using System;
using System.Collections.Generic;
using System.Text;
using FifthFloor.Data.EntityClasses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FifthFloor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<EmploymentLocation> EmploymentLocations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //
            // EMployment Locations
            //
            builder.Entity<EmploymentLocation>().ToTable("EmploymentLocations", "FifthFloor");
            builder.Entity<EmploymentLocation>().HasKey(el => el.EmploymentLocationId);
            builder.Entity<EmploymentLocation>().Property(el => el.EmploymentLocationId).UseIdentityColumn();
            builder.Entity<EmploymentLocation>().Property(el => el.Name).IsRequired().HasMaxLength(100);
            builder.Entity<EmploymentLocation>().Property(el => el.StreetAddress).HasMaxLength(100);
            builder.Entity<EmploymentLocation>().Property(el => el.City).HasMaxLength(100);
            builder.Entity<EmploymentLocation>().Property(el => el.State).HasMaxLength(100);
            builder.Entity<EmploymentLocation>().Property(el => el.PostalCode).HasMaxLength(25);
            builder.Entity<EmploymentLocation>().Property(el => el.Latitude).HasColumnType("Decimal(9,6)");
            builder.Entity<EmploymentLocation>().Property(el => el.Longitude).HasColumnType("Decimal(9,6)");
            builder.Entity<EmploymentLocation>().HasData(
                new EmploymentLocation 
                {
                    EmploymentLocationId = 1, Name = "Orlando" 
                });
        }
    }
}
