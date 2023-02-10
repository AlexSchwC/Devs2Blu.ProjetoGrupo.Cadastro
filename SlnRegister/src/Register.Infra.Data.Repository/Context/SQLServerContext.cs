using Microsoft.EntityFrameworkCore;
using System;
using Register.Domain.Enums;
using Register.Domain.Entities;
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
            new { Id = 1, Name = "Critical" },
            new { Id = 2, Name = "Serious" },
            new { Id = 3, Name = "Fair" },
            new { Id = 4, Name = "Good" },
            new { Id = 5, Name = "Undetermined" }
            );

            // Seed
            modelBuilder.Entity<Specialty>()
                .HasData(
                new { Id = 1, Name = "Pediatric" },
                new { Id = 2, Name = "Cardiology" },
                new { Id = 3, Name = "Dermatology" },
                new { Id = 4, Name = "Gastroenterology" }
                );

            modelBuilder.Entity<Person>()
                .HasData(
                new {Id = 1, Name = "Maria Clara de Souza", Age = "25", CPF = "123.456.789-12"},
                new { Id = 2, Name = "Paulo Moreira", Age = "47", CPF = "789.456.123-78" },
                new { Id = 3, Name = "Rafaella Rodrigues da Silva", Age = "16", CPF = "753.159.456-58" },
                new { Id = 4, Name = "João de Oliveira", Age = "52", CPF = "951.357.321-56" },
                new { Id = 5, Name = "Clara Maria Moretti", Age = "24", CPF = "741.852.963-37" },
                new { Id = 6, Name = "Ricardo Alves de Souza", Age = "31", CPF = "963.852.741-15" },
                new { Id = 7, Name = "Helena Muller", Age = "27", CPF = "248.862.176-49" },
                new { Id = 8, Name = "Gabriel Bugmann Vanzuita", Age = "40", CPF = "154.268.729-16" },
                new { Id = 9, Name = "Laura Elena Fisher", Age = "38", CPF = "217.369.252-98" }
                );

            modelBuilder.Entity<Patient>()
                .HasData(
                new {Id = 1, PersonId = 1, ConditionId = 3},
                new { Id = 2, PersonId = 2, ConditionId = 3 },
                new { Id = 3, PersonId = 3, ConditionId = 1 }
                );

            modelBuilder.Entity<Doctor>()
                .HasData(
                new {Id = 1, PersonId = 4, SpecialtyId = 4, CNPJ = "12.234.567/0001-89", CRM = "CRM/SP 123456" },
                new { Id = 2, PersonId = 5, SpecialtyId = 1, CNPJ = "56.741.963/0001-42", CRM = "CRM/SC 456983" },
                new { Id = 3, PersonId = 6, SpecialtyId = 2, CNPJ = "89.466.123/0001-26", CRM = "CRM/RS 123147" }
                );

            modelBuilder.Entity<Receptionist>()
                .HasData(
                new {Id = 1, PersonId = 7, PIS = "170.33259.50-4" },
                new { Id = 2, PersonId = 8, PIS = "892.15933.47-9" },
                new { Id = 3, PersonId = 9, PIS = "741.75321.32-4" }
                );

            /*modelBuilder.Entity<User>()
                .HasData(
                new {Id = 1, PersonId = 1, Username = "maria clara", Password = "123", Email = "maria@gmail.com", PersonType = PersonTypeEnum.Patient},
                new {Id = 2, PersonId = 2, Username = "paulo", Password = "123", Email = "paulo@gmail.com", PersonType = PersonTypeEnum.Patient},
                new { Id = 3, PersonId = 3, Username = "rafa", Password = "123", Email = "rafaella@gmail.com", PersonType = PersonTypeEnum.Patient },
                new { Id = 4, PersonId = 4, Username = "joao", Password = "123", Email = "joao@gmail.com", PersonType = PersonTypeEnum.Doctor},
                new { Id = 5, PersonId = 5, Username = "clara", Password = "123", Email = "clara@gmail.com", PersonType = PersonTypeEnum.Doctor },
                new { Id = 6, PersonId = 6, Username = "ricardo", Password = "123", Email = "ricardo@gmail.com", PersonType = PersonTypeEnum.Doctor },
                new { Id = 7, PersonId = 7, Username = "helena", Password = "123", Email = "helena@gmail.com", PersonType = PersonTypeEnum.Receptionist },
                new { Id = 8, PersonId = 8, Username = "gabriel", Password = "123", Email = "gabriel@gmail.com", PersonType = PersonTypeEnum.Receptionist },
                new { Id = 9, PersonId = 9, Username = "laura", Password = "123", Email = "laura@gmail.com", PersonType = PersonTypeEnum.Receptionist }
                );
            */
        }
        #region DBSets<Tables>

        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
    }
}

