using System.Collections.Generic;

namespace webdemo2
{
    public class Car
    {
        public int CarID { get; set; }
        public int MaxSpeed { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public ICollection<CarRegister> RegistryEntries { get; set; }

    }
}
