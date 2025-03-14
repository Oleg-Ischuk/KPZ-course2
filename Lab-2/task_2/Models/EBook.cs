using System;

namespace task_2.Models
{
    public class EBook : Device
    {
        public EBook(string brand) : base(brand, "EBook", 6.0, 0.2, 2000, 32)
        {
        }
    }
}
