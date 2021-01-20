using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdemo2.Data
{
    public class Repository : IRepository
    {
        private IRepository repo;
        public Repository(IRepository repository)
        {
            repo = repository;
        }
        public int CountAllPeople()
        {
            var result = repo.CountAllPeople();
            return repo.CountAllPeople();
        }
       public async Task<Person> GetPersonAsync(int? id)
        {
            await Task.Delay(0);
            return  new Person { Firstname = "Erik" };
        }

    }
    public interface IRepository
    {
        int CountAllPeople();
        Task<Person> GetPersonAsync(int? id);
    }
}
