using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using webdemo2.Data;

namespace webdemo2.Repositories
{
    public class DbOperations : IDbOperations
    {
        private readonly CarContext context;
        public DbOperations(CarContext context)
        {
            this.context = context;
        }
        public async Task<Person> GetPersonAsync(int id)
        {
            return await context.Persons
                .FirstOrDefaultAsync(x => x.PersonID == 1);
        }

        public Person GetPersonWithCars()
        {
            return context.Persons
                .Include(x => x.RegistryEntries)
             //   .Where(x => x.Firstname == "Erik")
             .Where(x => x.PersonID == 1)
                .FirstOrDefault();
        }

        public Person AddPerson(string firstname, string lastname)
        {
            var person = new Person { Firstname = firstname, Lastname = lastname };
            context.Persons.Add(person);
            context.SaveChanges();
            return person;
        }

        public Car AddCar(string make, string model)
        {
            var car = new Car { Make = make, Model = model };
            context.Cars.Add(car);
            context.SaveChanges();
            return car;
        }

        public async Task<Car> GetCarAsync(int id)
        {
            return await context.Cars.FirstOrDefaultAsync(x => x.CarID == id);
        }

        public async Task<CarRegister> AddCarToRegisterAsync(Car car, Person person)
        {
            var registry = new CarRegister
            {
                Car = car,
                Person = person
            };
            await context.AddAsync(registry);

            // felhantering
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException sqlException = ex.InnerException as SqlException;
                if (sqlException.Number == 2627)
                {
                    throw new Exception("Den där posten har redan lagrats", ex);
                }
                throw;
            }
            return registry;
        }
    }
}
