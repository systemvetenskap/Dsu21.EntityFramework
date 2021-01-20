using System.ComponentModel.DataAnnotations.Schema;

namespace webdemo2
{
    public class CarRegister
    {
        public int CarID { get; set; }
        public Car Car { get; set; }

        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
