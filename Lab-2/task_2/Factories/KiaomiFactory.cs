using task_2.Interfaces;
using task_2.Models;

namespace task_2.Factories
{
    public class KiaomiFactory : IDeviceFactory
    {
        public Laptop CreateLaptop() => new Laptop("Kiaomi");
        public Smartphone CreateSmartphone() => new Smartphone("Kiaomi");
        public EBook CreateEBook() => new EBook("Kiaomi");
        public Netbook CreateNetbook() => new Netbook("Kiaomi");
    }
}
