using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var warehouse = new Warehouse();
            var reporting = new Reporting(warehouse);

            var priceBread = new Money(2, 50, "UAH");
            var productBread = new Product("Хліб", priceBread, "Продукти");
            reporting.RegisterIncome(productBread, 30, "шт");

            var priceMilk = new Money(3, 75, "UAH");
            var productMilk = new Product("Молоко", priceMilk, "Продукти");
            reporting.RegisterIncome(productMilk, 20, "л");

            var priceApples = new Money(1, 25, "UAH");
            var productApples = new Product("Яблука", priceApples, "Фрукти");
            reporting.RegisterIncome(productApples, 50, "кг");

            reporting.InventoryReport();

            reporting.RegisterOutcome("Хліб", 5);
            reporting.RegisterOutcome("Молоко", 10);
            reporting.InventoryReport();

            Console.WriteLine("Зменшення ціни на 0.50 грн для хліба");
            productBread.ReducePrice(new Money(0, 50, "UAH"));
            Console.WriteLine($"Нова ціна хліба: {productBread}");

            Console.WriteLine("Зменшення ціни на 1.00 грн для молока");
            productMilk.ReducePrice(new Money(1, 0, "UAH"));
            Console.WriteLine($"Нова ціна молока: {productMilk}");

            reporting.InventoryReport();

            reporting.RegisterOutcome("Яблука", 60);
            reporting.RegisterOutcome("Неіснуючий товар", 1);
            reporting.InventoryReport();
        }
    }
}
