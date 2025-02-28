using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Warehouse
    {
        public List<Dictionary<string, object>> Products { get; set; }

        public Warehouse()
        {
            Products = new List<Dictionary<string, object>>();
        }

        public void AddProduct(Product product, int quantity, string unit, DateTime lastDelivery)
        {
            Products.Add(new Dictionary<string, object>
            {
                { "product", product },
                { "quantity", quantity },
                { "unit", unit },
                { "last_delivery", lastDelivery }
            });

            Console.WriteLine($"Додано товар: {product.ToString()}");
        }

        public override string ToString()
        {
            var report = "";
            foreach (var item in Products)
            {
                var product = (Product)item["product"];
                var quantity = (int)item["quantity"];
                var unit = (string)item["unit"];
                var lastDelivery = (DateTime)item["last_delivery"];
                report += $"{product.ToString()} - {quantity} {unit} (Остання доставка: {lastDelivery:yyyy-MM-dd HH:mm:ss})\n";
            }
            return report;
        }
    }
}
