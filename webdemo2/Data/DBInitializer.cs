using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdemo2.Data
{
    public static class DBInitializer
    {
        public static void Initialize(CarContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Persons.Any())
            {
                return;   // DB has been seeded
            }

            var persons = new Person[]
            {
                new Person{ Firstname="Erik"},
                new Person{ Firstname="Eva"},
                new Person{ Firstname="Charlie"},
                new Person{ Firstname="Thomas"},
                new Person{ Firstname="Benjamin"},
            };

            foreach (Person person in persons)
            {
                context.Persons.Add(person);
            }
            context.SaveChanges();

            var cars = new Car[]
            {
                new Car{Make="Ascona", Model="Opel"},
                new Car{Make="Audi", Model="Q5"},
            };
            foreach (Car car in cars)
            {
                context.Cars.Add(car);
            }
            context.SaveChanges();

            var register = new CarRegister[]
            {
                new CarRegister{ CarID=1, PersonID=1},
                new CarRegister{ CarID=1, PersonID=2},
                new CarRegister{ CarID=2, PersonID=1},
            };
            foreach (CarRegister item in register)
            {
                context.CarRegisters.Add(item);
            }
            context.SaveChanges();
        }
    }
}
