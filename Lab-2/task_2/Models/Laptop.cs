using System;

namespace task_2.Models
{
    public class Laptop : Device
    {
        public Laptop(string brand) : base(brand, "Laptop", 15.6, 1.5, 5000, 512)
        {
        }
    }
}
