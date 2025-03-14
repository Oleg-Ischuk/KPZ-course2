using System;
using VirusLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("⚠️  Симуляція мутації вірусів! ⚠️\n");
        Console.ResetColor();

        try
        {
            RunVirusSimulation();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ Помилка: {ex.Message}");
            Console.ResetColor();
        }
    }

    private static void RunVirusSimulation()
    {
        Console.WriteLine("=== 🔬 Створення вірусного дерева ===\n");
        var rootVirus = new Virus("Omega-Core", "Бактеріофаг", 0.06, 110);
        var variant1 = new Virus("Sigma-X", "Бактеріофаг", 0.05, 90);
        var variant2 = new Virus("Theta-Y", "Бактеріофаг-Мутант", 0.045, 75);
        var variant3 = new Virus("Delta-Z", "Бактеріофаг-Мутант", 0.04, 60);

        rootVirus.AddMutation(variant1);
        variant1.AddMutation(variant2);
        variant1.AddMutation(variant3);

        Console.WriteLine("🔍 Оригінальне вірусне дерево:");
        rootVirus.DisplayMutationTree();

        SimulateCloning(rootVirus);
    }

    private static void SimulateCloning(Virus rootVirus)
    {
        Console.WriteLine("\n=== 🧪 Клонування вірусного дерева ===\n");
        var clonedVirus = (Virus)rootVirus.Clone();
        Console.WriteLine("🆕 Клоноване вірусне дерево:");
        clonedVirus.DisplayMutationTree();

        ValidateCloning(rootVirus, clonedVirus);
    }

    private static void ValidateCloning(Virus original, Virus clone)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n=== ✅ Перевірка клонування ===");
        Console.WriteLine($"Оригінал і клон - різні об'єкти: {!ReferenceEquals(original, clone)}");

        if (original.Mutations.Count > 0 && clone.Mutations.Count > 0)
        {
            Console.WriteLine($"Мутації - різні об'єкти: {!ReferenceEquals(original.Mutations[0], clone.Mutations[0])}\n");
        }
        Console.ResetColor();
    }
}
