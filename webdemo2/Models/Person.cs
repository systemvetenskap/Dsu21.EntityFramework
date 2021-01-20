using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdemo2
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Firstname{ get; set; }
        public string Lastname { get; set; }
        public ICollection<CarRegister> RegistryEntries { get; set; }
    }
}
