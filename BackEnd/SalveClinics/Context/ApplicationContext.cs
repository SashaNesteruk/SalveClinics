using Microsoft.EntityFrameworkCore;
using SalveClinics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalveClinics.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>()
                .HasMany(x => x.Patients)
                .WithOne()
                .HasForeignKey(x => x.ClinicId);

            modelBuilder.Entity<Patient>().HasKey(x => x.Id);


        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
