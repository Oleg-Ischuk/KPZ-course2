using task_2.Models;

namespace task_2.Interfaces
{
    public interface IDeviceFactory
    {
        Laptop CreateLaptop();
        Smartphone CreateSmartphone();
        EBook CreateEBook();
        Netbook CreateNetbook();
    }
}
