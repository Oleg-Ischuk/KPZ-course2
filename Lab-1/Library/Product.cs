using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Product
    {
        public string Name { get; set; }
        public Money Price { get; set; }
        public string Category { get; set; }

        public Product(string name, Money price, string category = "Загальна")
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public void ReducePrice(Money amount)
        {
            int totalCents = Price.Whole * 100 + Price.Cents - (amount.Whole * 100 + amount.Cents);
            Price.SetValue(totalCents / 100, totalCents % 100);
        }

        public override string ToString()
        {
            return $"{Name} ({Category}): {Price.ToString()}";
        }
    }
}
