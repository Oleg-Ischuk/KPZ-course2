using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Reporting
    {
        public Warehouse Warehouse { get; set; }

        public Reporting(Warehouse warehouse)
        {
            Warehouse = warehouse;
        }

        public void RegisterIncome(Product product, int quantity, string unit)
        {
            Warehouse.AddProduct(product, quantity, unit, DateTime.Now);
            Console.WriteLine($"Зареєстровано надходження: {product.ToString()} - {quantity} {unit}\n");
        }

        public void RegisterOutcome(string productName, int quantity)
        {
            foreach (var item in Warehouse.Products)
            {
                var product = (Product)item["product"];
                var unit = (string)item["unit"];
                if (product.Name == productName)
                {
                    var currentQuantity = (int)item["quantity"];
                    if (currentQuantity >= quantity)
                    {
                        item["quantity"] = currentQuantity - quantity;
                        Console.WriteLine($"Зареєстровано відвантаження: {product.ToString()} - {quantity} {unit}");
                    }
                    else
                    {
                        Console.WriteLine($"Недостатньо товару: {product.ToString()}");
                    }
                    return;
                }
            }
            Console.WriteLine($"Товар {productName} не знайдено на складі");
        }

        public void InventoryReport()
        {
            Console.WriteLine("Звіт про інвентаризацію:");
            Console.WriteLine(Warehouse.ToString());
        }
    }
}
