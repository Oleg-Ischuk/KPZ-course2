using task_2.Interfaces;
using task_2.Models;

namespace task_2.Factories
{
    public class IProneFactory : IDeviceFactory
    {
        public Laptop CreateLaptop() => new Laptop("IProne");
        public Smartphone CreateSmartphone() => new Smartphone("IProne");
        public EBook CreateEBook() => new EBook("IProne");
        public Netbook CreateNetbook() => new Netbook("IProne");
    }
}
