using System.Threading.Tasks;

namespace webdemo2.Repositories
{
    public interface IDbOperations
    {
        Car AddCar(string make, string model);
        Task<CarRegister> AddCarToRegisterAsync(Car car, Person person);
        Person AddPerson(string firstname, string lastname);
        Task<Car> GetCarAsync(int id);
        Task<Person> GetPersonAsync(int id);
        Person GetPersonWithCars();
    }
}
