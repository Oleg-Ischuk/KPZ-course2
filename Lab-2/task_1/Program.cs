using System;
using System.Collections.Generic;

public abstract class Subscription
{
    public string Name { get; }
    public double MonthlyFee { get; }
    public int MinPeriod { get; }
    public List<string> Channels { get; }

    protected Subscription(string name, double fee, int minPeriod, List<string> channels)
    {
        Name = name;
        MonthlyFee = fee;
        MinPeriod = minPeriod;
        Channels = channels;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"\n{Name}");
        Console.WriteLine($"Cost: {MonthlyFee:0.00} UAH/month");
        Console.WriteLine($"Minimum period: {MinPeriod} months");
        Console.WriteLine($"Channels: {string.Join(", ", Channels)}\n");
    }
}

public class DomesticSubscription : Subscription
{
    public DomesticSubscription() 
        : base("Domestic Subscription", 160, 3, new List<string> { "Local News", "Regional Sports", "Classic Movies", "Pop Music" }) { }
}

public class EducationalSubscription : Subscription
{
    public EducationalSubscription() 
        : base("Educational Subscription", 100, 6, new List<string> { "Math", "Physics", "History", "Computer Science" }) { }
}

public class PremiumSubscription : Subscription
{
    public PremiumSubscription() 
        : base("Premium Subscription", 300, 1, new List<string> { "Blockbuster Movies", "Live Sports", "Exclusive Series", "Prime Video" }) { }
}

public interface ISubscriptionFactory
{
    Subscription CreateSubscription();
}

public class WebSite : ISubscriptionFactory
{
    public Subscription CreateSubscription() => new DomesticSubscription();
}

public class MobileApp : ISubscriptionFactory
{
    public Subscription CreateSubscription() => new EducationalSubscription();
}

public class ManagerCall : ISubscriptionFactory
{
    public Subscription CreateSubscription() => new PremiumSubscription();
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the subscription service!\n");
            Console.WriteLine("Choose a subscription method:");
            Console.WriteLine("1 - Website");
            Console.WriteLine("2 - Mobile App");
            Console.WriteLine("3 - Manager Call");
            Console.WriteLine("0 - Exit");
            Console.Write("\nYour choice: ");
            
            string? input = Console.ReadLine();
            if (input == "0") break;

            ISubscriptionFactory? factory = input switch
            {
                "1" => new WebSite(),
                "2" => new MobileApp(),
                "3" => new ManagerCall(),
                _ => null
            };

            if (factory != null)
            {
                Subscription subscription = factory.CreateSubscription();
                subscription.DisplayInfo();
            }
            else
            {
                Console.WriteLine("\n❌ Invalid choice! Please try again.\n");
            }
        }

        Console.WriteLine("\nThank you for using the subscription service! 😊");
    }
}