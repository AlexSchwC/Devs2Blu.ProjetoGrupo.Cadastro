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
                new {Id = 1, Name = "Maria Clara de Souza", BirthDate = new DateTime(2000, 12, 31), CPF = "123.456.789-12", Gender = GenderEnum.Feminino},
                new { Id = 2, Name = "Paulo Moreira", BirthDate = new DateTime(2000, 12, 31), CPF = "789.456.123-78", Gender = GenderEnum.Masculino},
                new { Id = 3, Name = "Rafaella Rodrigues da Silva", BirthDate = new DateTime(2000, 12, 31), CPF = "753.159.456-58", Gender = GenderEnum.Feminino },
                new { Id = 4, Name = "João de Oliveira", BirthDate = new DateTime(2000, 12, 31), CPF = "951.357.321-56", Gender = GenderEnum.Masculino },
                new { Id = 5, Name = "Clara Maria Moretti", BirthDate = new DateTime(2000, 12, 31), CPF = "741.852.963-37", Gender = GenderEnum.Feminino },
                new { Id = 6, Name = "Ricardo Alves de Souza", BirthDate = new DateTime(2000, 12, 31), CPF = "963.852.741-15", Gender = GenderEnum.Masculino },
                new { Id = 7, Name = "Helena Muller", BirthDate = new DateTime(2000, 12, 31), CPF = "248.862.176-49", Gender = GenderEnum.Feminino },
                new { Id = 8, Name = "Gabriel Bugmann Vanzuita", BirthDate = new DateTime(2000, 12, 31), CPF = "154.268.729-16", Gender = GenderEnum.Masculino },
                new { Id = 9, Name = "Laura Elena Fisher", BirthDate = new DateTime(2000, 12, 31), CPF = "217.369.252-98", Gender = GenderEnum.Feminino }
                );

            modelBuilder.Entity<Patient>()
                .HasData(
                new {Id = 1, MRNumber = 1, PersonId = 1, ConditionId = 3},
                new { Id = 2, MRNumber = 2, PersonId = 2, ConditionId = 3 },
                new { Id = 3, MRNumber = 3, PersonId = 3, ConditionId = 1 }
                );

            modelBuilder.Entity<Doctor>()
                .HasData(
                new {Id = 1, PersonId = 4, SpecialtyId = 4, CNPJ = "12.234.567/0001-89", CRM = "CRM/SP 123456" },
                new { Id = 2, PersonId = 5, SpecialtyId = 1, CNPJ = "56.741.963/0001-42", CRM = "CRM/SC 456983" },
                new { Id = 3, PersonId = 6, SpecialtyId = 2, CNPJ = "89.466.123/0001-26", CRM = "CRM/RS 123147" }
                );

            modelBuilder.Entity<Address>()
                .HasData(
                new {Id = 1, PersonId = 1, City = "Blumenau", PostalCode = "89012-412", District = "SC", Street = "Rua Curitiba", Number = "123" },
                new { Id = 2, PersonId = 2, City = "Blumenau", PostalCode = "89051-260", District = "SC", Street = "Rua Pedro Francisco Cordeiro", Number = "453" },
                new { Id = 3, PersonId = 3, City = "Blumenau", PostalCode = "89051-170", District = "SC", Street = "Rua Caiena", Number = "1963" },
                new { Id = 4, PersonId = 4, City = "Blumenau", PostalCode = "89046-636", District = "SC", Street = "Rua Áustria", Number = "2587" },
                new { Id = 5, PersonId = 5, City = "Blumenau", PostalCode = "89027-351", District = "SC", Street = "Rua Bruno Hort", Number = "8746" },
                new { Id = 6, PersonId = 6, City = "Blumenau", PostalCode = "89022-275", District = "SC", Street = "Rua Turvo", Number = "7895" },
                new { Id = 7, PersonId = 7, City = "Blumenau", PostalCode = "89095-510", District = "SC", Street = "Rua Otto Manzke", Number = "753" },
                new { Id = 8, PersonId = 8, City = "Blumenau", PostalCode = "89057-496", District = "SC", Street = "Rua Augusto Setter", Number = "951" },
                new { Id = 9, PersonId = 9, City = "Blumenau", PostalCode = "89095-525", District = "SC", Street = "Rua Três Primos", Number = "852" }
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
        public DbSet<User> Users { get; set; }
        #endregion
    }
}

