using System;

namespace task_2.Models
{
    public class Smartphone : Device
    {
        public Smartphone(string brand) : base(brand, "Smartphone", 6.5, 0.3, 4000, 128)
        {
        }
    }
}
