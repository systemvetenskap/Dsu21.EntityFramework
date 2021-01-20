using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webdemo2.Data;

namespace webdemo2.Repositories
{
    public class CarOperations : ICarOperations
    {
        CarContext db;

        public CarOperations(CarContext context)
        {
            db = context;
        }
        public Car GetCar(int id)
        {
            var car = db.Cars
                .Include(x => x.RegistryEntries)
                .Where(x => x.CarID == id)
                
                .FirstOrDefault();
            return car;
        }

        public Car AddCar(string make, string model)
        {
            var car = new Car
            {
                Make = make,
                Model = model
            };
            db.Add(car);
            db.SaveChanges();
            return car;
        }

        public async Task<Person> AddPersonAsync(string firstname, string lastname)
        {
            var person = new Person
            {
                Firstname = firstname,
                Lastname = lastname
            };
            await db.AddAsync(person);
            db.SaveChanges();
            return person;
        }

        public void AddCarRegistry(Car car, Person person = null)
        {
            person = db.Persons
                .Where(x => x.PersonID == 1).FirstOrDefault();
            var reg = new CarRegister
            {
                Car = car,
                Person = person
            };

            db.Add(reg);
            db.SaveChanges();
        }

    }
}
