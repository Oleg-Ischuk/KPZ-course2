using System;

namespace task_2.Models
{
    public class Netbook : Device
    {
        public Netbook(string brand) : base(brand, "Netbook", 11.0, 1.2, 3500, 64)
        {
        }
    }
}
