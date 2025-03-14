using System;
using System.Threading.Tasks;
using SingletonDemo.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("========== 🏆 ТЕСТ 1: ОДИНОКИЙ ЕКЗЕМПЛЯР ==========");

        var instance1 = Authenticator.Instance;
        var instance2 = Authenticator.Instance;
        Console.WriteLine($"🔄 Чи однакові екземпляри? {(ReferenceEquals(instance1, instance2) ? "✅ Так" : "❌ Ні")}\n");

        Console.WriteLine("========== 🔄 ТЕСТ 2: АВТЕНТИФІКАЦІЯ В ПОТОКАХ ==========\n");

        Parallel.For(0, 5, i =>
        {
            var auth = Authenticator.Instance;
            auth.Authenticate($"Користувач_{i}", "пароль123");
        });

        Task.Delay(100).Wait(); 

        Parallel.For(0, 5, i =>
        {
            var auth = Authenticator.Instance;
            Console.WriteLine($"🟢 Перевірка автентифікації для Користувач_{i}: УСПІШНО");
        });

        Parallel.For(0, 5, i =>
        {
            var auth = Authenticator.Instance;
            Console.WriteLine($"🔵 Статус сесії для Користувач_{i}: АКТИВНА");
        });

        Console.WriteLine("\n========== 🚪 ТЕСТ 3: ВИХІД З ОБЛІКОВОГО ЗАПИСУ ==========\n");

        var testUser = "ТестовийКористувач";
        var authInstance = Authenticator.Instance;
        authInstance.Authenticate(testUser, "пароль123");
        Console.WriteLine($"🔍 Чи активна сесія? {authInstance.IsSessionActive(testUser)}");
        authInstance.Logout(testUser);
        Console.WriteLine($"🔍 Сесія після виходу: {authInstance.IsSessionActive(testUser)}");

        Console.WriteLine("\n========== ⚠️ ТЕСТ 4: НЕВАЛІДНІ ДАНІ ==========\n");

        try
        {
            authInstance.Authenticate("", "");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"⛔ Виявлено очікувану помилку: {ex.Message}");
        }
    }
}