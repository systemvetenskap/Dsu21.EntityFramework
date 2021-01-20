using System.Threading.Tasks;

namespace webdemo2.Repositories
{
    public interface ICarOperations
    {
        Car AddCar(string make, string model);
        void AddCarRegistry(Car car, Person person = null);
        Task<Person> AddPersonAsync(string firstname, string lastname);
        Car GetCar(int id);
    }
}
