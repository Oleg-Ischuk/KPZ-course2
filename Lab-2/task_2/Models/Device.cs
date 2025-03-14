using System;

namespace task_2.Models
{
    public abstract class Device
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; } 
        public double DisplaySize { get; set; }
        public double Weight { get; set; } 
        public double BatteryCapacity { get; set; } 
        public double Storage { get; set; } 

        public Device(string brand, string model, double displaySize, double weight, double batteryCapacity, double storage)
        {
            Brand = brand;
            Model = model;
            DisplaySize = displaySize;
            Weight = weight;
            BatteryCapacity = batteryCapacity;
            Storage = storage;

            Price = GenerateRandomPrice(); 
        }

        private double GenerateRandomPrice()
        {
            Random random = new Random();
            return Math.Round(random.NextDouble() * (2500 - 200) + 200, 2); 
        }
    }
}
