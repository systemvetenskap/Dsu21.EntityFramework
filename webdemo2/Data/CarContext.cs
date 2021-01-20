using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webdemo2.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarRegister> CarRegisters { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<CarRegister>().ToTable("Carregister");
            modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<CarRegister>()
            .HasKey(t => new { t.CarID, t.PersonID });

            modelBuilder.Entity<CarRegister>()
                .HasOne(pt => pt.Car)
                .WithMany(p => p.RegistryEntries)
                .HasForeignKey(pt => pt.CarID);

            modelBuilder.Entity<CarRegister>()
                .HasOne(pt => pt.Person)
                .WithMany(t => t.RegistryEntries)
                .HasForeignKey(pt => pt.PersonID);
        }

    }
}
