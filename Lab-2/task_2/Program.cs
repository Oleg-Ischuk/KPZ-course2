using System;
using task_2.Factories;
using task_2.Interfaces;
using task_2.Models;
using System.Collections.Generic;

class Program
{
    static List<Device> inventory = new List<Device>(); 
    static Random random = new Random(); 

    static void Main()
    {
        Console.WriteLine("🎉 Ласкаво просимо на фабрику техніки!\n");

    while (true)
    {
        Console.WriteLine("\n[!] 1. Переглянути пристрої за брендом.");
        Console.WriteLine("[!] 2. Показати статистику продажів.");
        Console.WriteLine("[!] 3. Порівняти вартість брендів.");
        Console.WriteLine("[!] 4. Очистити список пристроїв.");
        Console.WriteLine("[!] 0. Вийти з програми.");
        Console.Write("\nВаш вибір: ");
        string? input = Console.ReadLine();
        
        switch (input)
        {
            case "1":
                ShowProductsByBrand();
                break;
            case "2":
                ShowStoreStatistics();
                break;
            case "3":
                ComparePrices();
                break;
            case "4":
                ClearInventory();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("\n❌ Некоректний вибір! Спробуйте ще раз.\n");
                break;
        }
    }
    }

    static void ShowProductsByBrand()
    {
        Console.WriteLine("\nОбери бренд:");
        Console.WriteLine("1 - IProne");
        Console.WriteLine("2 - Kiaomi");
        Console.WriteLine("3 - Balaxy");
        Console.WriteLine("0 - Повернутися назад");
        Console.Write("\nВаш вибір: ");
        
        string? input = Console.ReadLine();
        IDeviceFactory? factory = input switch
        {
            "1" => new IProneFactory(),
            "2" => new KiaomiFactory(),
            "3" => new BalaxyFactory(),
            _ => null
        };

        if (factory != null)
        {
            Console.WriteLine("\nСтворюємо пристрої...\n");

            Device laptop = factory.CreateLaptop();
            Device smartphone = factory.CreateSmartphone();
            Device ebook = factory.CreateEBook();
            Device netbook = factory.CreateNetbook();

            inventory.AddRange(new[] { laptop, smartphone, ebook, netbook });

            DisplayDeviceInfo(laptop);
            DisplayDeviceInfo(smartphone);
            DisplayDeviceInfo(ebook);
            DisplayDeviceInfo(netbook);
        }
        else if (input != "0")
        {
            Console.WriteLine("\n❌ Некоректний вибір!\n");
        }
    }

    static void ShowStoreStatistics()
    {
   
        var brands = new Dictionary<string, (int count, double totalValue)>
        {
            { "IProne", (0, 0) },
            { "Kiaomi", (0, 0) },
            { "Balaxy", (0, 0) }
        };

        foreach (var device in inventory)
        {
            if (brands.ContainsKey(device.Brand))
            {
                brands[device.Brand] = (brands[device.Brand].count + 1, brands[device.Brand].totalValue + device.Price);
            }
        }

        foreach (var brand in brands)
        {
            Console.WriteLine($"\nБренд: {brand.Key}");
            Console.WriteLine($"Кількість створених товарів: {brand.Value.count}");
            Console.WriteLine($"Загальна вартість: {brand.Value.totalValue:F2} USD");
        }
    }

    static void ComparePrices()
    {
        var brands = new Dictionary<string, double>
        {
            { "IProne", 0 },
            { "Kiaomi", 0 },
            { "Balaxy", 0 }
        };

        foreach (var device in inventory)
        {
            if (brands.ContainsKey(device.Brand))
            {
                brands[device.Brand] += device.Price;
            }
        }

        Console.WriteLine("\nПорівняння цін між брендами:");
        foreach (var brand in brands)
        {
            Console.WriteLine($"Бренд: {brand.Key} | Загальна ціна: {brand.Value:F2} USD");
        }
    }

    static void ClearInventory()
    {
        inventory.Clear();
        Console.WriteLine("\nІнвентар очищений!\n");
    }

    static void DisplayDeviceInfo(Device device)
    {
        Console.WriteLine($"📱 {device.Brand} {device.Model}");
        Console.WriteLine($"📏 Дисплей: {device.DisplaySize}\"");
        Console.WriteLine($"💰 Ціна: {device.Price:F2} USD");
        Console.WriteLine($"⚖ Вага: {device.Weight} кг");
        Console.WriteLine($"🔋 Батарея: {device.BatteryCapacity} мАг");
        Console.WriteLine($"💾 Пам'ять: {device.Storage} ГБ");
        Console.WriteLine();
    }
}
