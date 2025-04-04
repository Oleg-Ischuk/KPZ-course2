using System;
using System.Collections.Generic;

namespace RPGDecoratorGame
{
    public abstract class Hero
    {
        public string Name { get; protected set; }
        public abstract int GetAttackPower();
        public abstract int GetDefensePower();
        public abstract string GetDescription();
    }

    public class Warrior : Hero
    {
        public Warrior(string name)
        {
            Name = name;
        }

        public override int GetAttackPower() => 10;
        public override int GetDefensePower() => 8;
        public override string GetDescription() => $"Воїн {Name}";
    }

    public class Mage : Hero
    {
        public Mage(string name)
        {
            Name = name;
        }

        public override int GetAttackPower() => 15;
        public override int GetDefensePower() => 3;
        public override string GetDescription() => $"Маг {Name}";
    }

    public class Paladin : Hero
    {
        public Paladin(string name)
        {
            Name = name;
        }

        public override int GetAttackPower() => 8;
        public override int GetDefensePower() => 12;
        public override string GetDescription() => $"Паладін {Name}";
    }

    public abstract class InventoryDecorator : Hero
    {
        protected Hero _hero;

        public InventoryDecorator(Hero hero)
        {
            _hero = hero;
            Name = hero.Name;
        }
    }

    public class Sword : InventoryDecorator
    {
        public Sword(Hero hero) : base(hero) { }

        public override int GetAttackPower() => _hero.GetAttackPower() + 5;
        public override int GetDefensePower() => _hero.GetDefensePower();
        public override string GetDescription() => $"{_hero.GetDescription()} з Мечем";
    }

    public class Staff : InventoryDecorator
    {
        public Staff(Hero hero) : base(hero) { }

        public override int GetAttackPower() => _hero.GetAttackPower() + 3;
        public override int GetDefensePower() => _hero.GetDefensePower() + 1;
        public override string GetDescription() => $"{_hero.GetDescription()} з Посохом";
    }

    public class PlateArmor : InventoryDecorator
    {
        public PlateArmor(Hero hero) : base(hero) { }

        public override int GetAttackPower() => _hero.GetAttackPower();
        public override int GetDefensePower() => _hero.GetDefensePower() + 7;
        public override string GetDescription() => $"{_hero.GetDescription()} у Латній Броні";
    }

    public class Robe : InventoryDecorator
    {
        public Robe(Hero hero) : base(hero) { }

        public override int GetAttackPower() => _hero.GetAttackPower() + 2;
        public override int GetDefensePower() => _hero.GetDefensePower() + 2;
        public override string GetDescription() => $"{_hero.GetDescription()} у Мантії";
    }

    public class MagicAmulet : InventoryDecorator
    {
        public MagicAmulet(Hero hero) : base(hero) { }

        public override int GetAttackPower() => _hero.GetAttackPower() + 4;
        public override int GetDefensePower() => _hero.GetDefensePower() + 2;
        public override string GetDescription() => $"{_hero.GetDescription()} з Магічним Амулетом";
    }

    public class ShieldOfProtection : InventoryDecorator
    {
        public ShieldOfProtection(Hero hero) : base(hero) { }

        public override int GetAttackPower() => _hero.GetAttackPower();
        public override int GetDefensePower() => _hero.GetDefensePower() + 5;
        public override string GetDescription() => $"{_hero.GetDescription()} зі Щитом Захисту";
    }

    class Program
    {
        static void DisplayHeroStats(Hero hero)
        {
            Console.WriteLine($"Опис: {hero.GetDescription()}");
            Console.WriteLine($"Сила атаки: {hero.GetAttackPower()}");
            Console.WriteLine($"Сила захисту: {hero.GetDefensePower()}");
            Console.WriteLine(new string('-', 80));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("РПГ Гра з Шаблоном Декоратор\n");

            Hero arthur = new Warrior("Артур");
            Console.WriteLine("Базовий Воїн:");
            DisplayHeroStats(arthur);

            arthur = new Sword(arthur);
            arthur = new PlateArmor(arthur);
            arthur = new ShieldOfProtection(arthur);
            Console.WriteLine("Воїн зі спорядженням:");
            DisplayHeroStats(arthur);

            Hero merlin = new Mage("Мерлін");
            Console.WriteLine("Базовий Маг:");
            DisplayHeroStats(merlin);

            merlin = new Staff(merlin);
            merlin = new Robe(merlin);
            merlin = new MagicAmulet(merlin);
            Console.WriteLine("Маг зі спорядженням:");
            DisplayHeroStats(merlin);

            Hero galahad = new Paladin("Галахад");
            Console.WriteLine("Базовий Паладін:");
            DisplayHeroStats(galahad);

            galahad = new Sword(galahad);
            galahad = new PlateArmor(galahad);
            galahad = new MagicAmulet(galahad);
            galahad = new ShieldOfProtection(galahad);
            Console.WriteLine("Паладін зі спорядженням:");
            DisplayHeroStats(galahad);

            Console.WriteLine("\n=== ДЕМОНСТРАЦІЯ ВИКОРИСТАННЯ КІЛЬКОХ ЕКЗЕМПЛЯРІВ ОДНОГО ПРЕДМЕТА ===\n");
            
            Hero lancelot = new Warrior("Ланселот");
            Console.WriteLine("Базовий Воїн (Ланселот):");
            DisplayHeroStats(lancelot);
            
            lancelot = new Sword(lancelot);
            Console.WriteLine("Ланселот з одним мечем:");
            DisplayHeroStats(lancelot);
            
            lancelot = new Sword(lancelot);
            Console.WriteLine("Ланселот з двома мечами:");
            DisplayHeroStats(lancelot);
            
            Hero morgana = new Mage("Моргана");
            Console.WriteLine("Базовий Маг (Моргана):");
            DisplayHeroStats(morgana);
            
            morgana = new MagicAmulet(morgana);
            Console.WriteLine("Моргана з одним Магічним Амулетом:");
            DisplayHeroStats(morgana);
            
            morgana = new MagicAmulet(morgana);
            Console.WriteLine("Моргана з двома Магічними Амулетами:");
            DisplayHeroStats(morgana);
            
            morgana = new MagicAmulet(morgana);
            Console.WriteLine("Моргана з трьома Магічними Амулетами:");
            DisplayHeroStats(morgana);

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}