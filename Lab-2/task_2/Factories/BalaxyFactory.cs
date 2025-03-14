using task_2.Interfaces;
using task_2.Models;

namespace task_2.Factories
{
    public class BalaxyFactory : IDeviceFactory
    {
        public Laptop CreateLaptop() => new Laptop("Balaxy");
        public Smartphone CreateSmartphone() => new Smartphone("Balaxy");
        public EBook CreateEBook() => new EBook("Balaxy");
        public Netbook CreateNetbook() => new Netbook("Balaxy");
    }
}
