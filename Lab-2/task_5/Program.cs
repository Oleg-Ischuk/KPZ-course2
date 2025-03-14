using System;
using Builders;
using Models;
using System.Collections.Generic;

class Program
{
    static List<Character> heroes = new List<Character>();
    static List<Character> enemies = new List<Character>();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Створення персонажів і битва ===");
            Console.WriteLine("1. Створити героя");
            Console.WriteLine("2. Створити ворога");
            Console.WriteLine("3. Переглянути героїв");
            Console.WriteLine("4. Переглянути ворогів");
            Console.WriteLine("5. Почати битву");
            Console.WriteLine("6. Очистити героїв");
            Console.WriteLine("7. Очистити ворогів");
            Console.WriteLine("8. Вийти");
            Console.Write("Оберіть опцію: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateHero();
                    break;
                case "2":
                    CreateEnemy();
                    break;
                case "3":
                    ViewCharacters(heroes, "Герої");
                    break;
                case "4":
                    ViewCharacters(enemies, "Вороги");
                    break;
                case "5":
                    StartBattle();
                    break;
                case "6":
                    ClearHeroes();
                    break;
                case "7":
                    ClearEnemies();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Натисніть Enter, щоб спробувати знову.");
                    Console.ReadLine();
                    break;
            }
        }

        Console.WriteLine("\nДо побачення! Натисніть будь-яку клавішу для виходу.");
        Console.ReadKey();
    }

    static void CreateHero()
    {
        Console.WriteLine("\n=== Створити героя ===");

        Console.Write("Введіть ім'я героя: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Ім'я не може бути порожнім.");
            return;
        }

        Console.Write("Введіть расу героя: ");
        string? race = Console.ReadLine();
        if (string.IsNullOrEmpty(race))
        {
            Console.WriteLine("Раса не може бути порожньою.");
            return;
        }

        Console.Write("Введіть клас героя: ");
        string? heroClass = Console.ReadLine();
        if (string.IsNullOrEmpty(heroClass))
        {
            Console.WriteLine("Клас не може бути порожнім.");
            return;
        }

        Console.Write("Введіть HP героя: ");
        string? hpInput = Console.ReadLine();
        if (string.IsNullOrEmpty(hpInput) || !int.TryParse(hpInput, out int hp))
        {
            Console.WriteLine("Невірне значення HP.");
            return;
        }

        Console.Write("Введіть колір волосся героя: ");
        string? hairColor = Console.ReadLine();
        if (string.IsNullOrEmpty(hairColor))
        {
            Console.WriteLine("Колір волосся не може бути порожнім.");
            return;
        }

        Console.Write("Введіть колір очей героя: ");
        string? eyeColor = Console.ReadLine();
        if (string.IsNullOrEmpty(eyeColor))
        {
            Console.WriteLine("Колір очей не може бути порожнім.");
            return;
        }

        Console.Write("Введіть одяг героя: ");
        string? outfit = Console.ReadLine();
        if (string.IsNullOrEmpty(outfit))
        {
            Console.WriteLine("Одяг не може бути порожнім.");
            return;
        }

        Console.Write("Введіть добрий вчинок героя: ");
        string? goodDeed = Console.ReadLine();
        if (string.IsNullOrEmpty(goodDeed))
        {
            Console.WriteLine("Добрий вчинок не може бути порожнім.");
            return;
        }

        var hero = new HeroBuilder()
            .SetName(name)
            .SetRace(race)
            .SetClass(heroClass)
            .SetHP(hp)
            .SetHairColor(hairColor)
            .SetEyeColor(eyeColor)
            .SetOutfit(outfit)
            .AddGoodDeed(goodDeed);

        AddInventoryToHero(hero);

        heroes.Add(hero.Build());

        Console.WriteLine("\nГерой створений успішно! Натисніть Enter, щоб повернутися до меню.");
        Console.ReadLine();
    }

    static void AddInventoryToHero(HeroBuilder heroBuilder)
    {
        Console.WriteLine("\n=== Додати предмети до інвентаря героя ===");
        List<string> items = new List<string>();
        
        string addMoreItems;
        do
        {
            Console.Write("Введіть назву предмета: ");
            string? item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }

            Console.Write("Бажаєте додати ще один предмет? (y/n): ");
            addMoreItems = Console.ReadLine()?.ToLower() ?? "n";
        }
        while (addMoreItems == "y");

        foreach (var item in items)
        {
            Console.Write($"Введіть кількість для предмета '{item}': ");
            string? quantityInput = Console.ReadLine();
            if (int.TryParse(quantityInput, out int quantity) && quantity > 0)
            {
                for (int i = 0; i < quantity; i++)
                {
                    heroBuilder.AddInventoryItem(item);
                }
            }
            else
            {
                Console.WriteLine("Невірна кількість предмета.");
            }
        }
    }

    static void CreateEnemy()
    {
        Console.WriteLine("\n=== Створити ворога ===");

        Console.Write("Введіть ім'я ворога: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Ім'я не може бути порожнім.");
            return;
        }

        Console.Write("Введіть расу ворога: ");
        string? race = Console.ReadLine();
        if (string.IsNullOrEmpty(race))
        {
            Console.WriteLine("Раса не може бути порожньою.");
            return;
        }

        Console.Write("Введіть клас ворога: ");
        string? enemyClass = Console.ReadLine();
        if (string.IsNullOrEmpty(enemyClass))
        {
            Console.WriteLine("Клас не може бути порожнім.");
            return;
        }

        Console.Write("Введіть HP ворога: ");
        string? hpInput = Console.ReadLine();
        if (string.IsNullOrEmpty(hpInput) || !int.TryParse(hpInput, out int hp))
        {
            Console.WriteLine("Невірне значення HP.");
            return;
        }

        Console.Write("Введіть колір волосся ворога: ");
        string? hairColor = Console.ReadLine();
        if (string.IsNullOrEmpty(hairColor))
        {
            Console.WriteLine("Колір волосся не може бути порожнім.");
            return;
        }

        Console.Write("Введіть колір очей ворога: ");
        string? eyeColor = Console.ReadLine();
        if (string.IsNullOrEmpty(eyeColor))
        {
            Console.WriteLine("Колір очей не може бути порожнім.");
            return;
        }

        Console.Write("Введіть одяг ворога: ");
        string? outfit = Console.ReadLine();
        if (string.IsNullOrEmpty(outfit))
        {
            Console.WriteLine("Одяг не може бути порожнім.");
            return;
        }

        Console.Write("Введіть злий вчинок ворога: ");
        string? evilDeed = Console.ReadLine();
        if (string.IsNullOrEmpty(evilDeed))
        {
            Console.WriteLine("Злий вчинок не може бути порожнім.");
            return;
        }

        var enemy = new EnemyBuilder()
            .SetName(name)
            .SetRace(race)
            .SetClass(enemyClass)
            .SetHP(hp)
            .SetHairColor(hairColor)
            .SetEyeColor(eyeColor)
            .SetOutfit(outfit)
            .AddEvilDeed(evilDeed)
            .Build();

        enemies.Add(enemy);

        Console.WriteLine("\nВорог створений успішно! Натисніть Enter, щоб повернутися до меню.");
        Console.ReadLine();
    }

    static void ViewCharacters(List<Character> characters, string type)
    {
        Console.WriteLine($"\n=== Перегляд {type} ===");
        if (characters.Count == 0)
        {
            Console.WriteLine($"Немає {type.ToLower()}.");
        }
        else
        {
            foreach (var character in characters)
            {
                character.PrintStats();
                Console.WriteLine();
            }
        }

        Console.WriteLine("\nНатисніть Enter, щоб повернутися до меню.");
        Console.ReadLine();
    }

    static void StartBattle()
    {
        if (heroes.Count == 0 || enemies.Count == 0)
        {
            Console.WriteLine("\nПотрібен хоча б один герой і один ворог для початку битви.");
            Console.WriteLine("\nНатисніть Enter, щоб повернутися до меню.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\n=== Почати битву ===");
        Console.WriteLine("Оберіть героя:");
        for (int i = 0; i < heroes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {heroes[i].Name}");
        }
        int heroIndex = int.Parse(Console.ReadLine() ?? "1") - 1;

        Console.WriteLine("Оберіть ворога:");
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {enemies[i].Name}");
        }
        int enemyIndex = int.Parse(Console.ReadLine() ?? "1") - 1;

        var hero = heroes[heroIndex];
        var enemy = enemies[enemyIndex];

        Battle(hero, enemy);
    }

    static void Battle(Character hero, Character enemy)
    {
        int turnCounter = 1;
        while (hero.HP > 0 && enemy.HP > 0)
        {
            Console.WriteLine($"--- Хід {turnCounter} ---");

            Console.WriteLine($"{hero.Name} атакує {enemy.Name}!");
            enemy.TakeDamage(20); 
            Console.WriteLine($"{enemy.Name} отримав 20 пошкоджень. HP тепер: {enemy.HP}\n");

            if (enemy.HP == 0) break;

            Console.WriteLine($"{enemy.Name} атакує {hero.Name}!");
            hero.TakeDamage(15); 
            Console.WriteLine($"{hero.Name} отримав 15 пошкоджень. HP тепер: {hero.HP}\n");

            turnCounter++;
        }

        Console.WriteLine("=== Результат битви ===");
        if (hero.HP > 0)
            Console.WriteLine("\nГерой виграв!");
        else
            Console.WriteLine("\nВорог виграв!");

        Console.WriteLine("\nНатисніть Enter, щоб повернутися до меню.");
        Console.ReadLine();
    }

    static void ClearHeroes()
    {
        heroes.Clear();
        Console.WriteLine("\nВсі герої були очищені. Натисніть Enter, щоб повернутися до меню.");
        Console.ReadLine();
    }

    static void ClearEnemies()
    {
        enemies.Clear();
        Console.WriteLine("\nВсі вороги були очищені. Натисніть Enter, щоб повернутися до меню.");
        Console.ReadLine();
    }
}
