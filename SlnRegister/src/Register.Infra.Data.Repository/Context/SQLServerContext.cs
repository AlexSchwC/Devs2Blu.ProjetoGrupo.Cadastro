using Microsoft.EntityFrameworkCore;
using Register.Domain.Entities;
using Register.Infra.Data.Repository.Repositories;
using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Infra.Data.Repository.Context 
{ 
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seed
            modelBuilder.Entity<Condition>()
            .HasData(
            new { Id = 1, Name = "Critical" }
            );

            // Seed
            modelBuilder.Entity<Specialty>()
                .HasData(
                new { Id = 1, Name = "Pediatric" },
                new { Id = 2, Name = "Cardiology" },
                new { Id = 3, Name = "Dermatology" },
                new { Id = 4, Name = "Gastroenterology" }
                );
        }
        #region DBSets<Tables>

        public DbSet<Condition> Condition { get; set; }
        public DbSet<Specialty> Specialty { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        #endregion
    }
}

