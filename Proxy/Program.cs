using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ISmartTextReader, SmartTextReader>();
builder.Services.AddSingleton<SmartTextChecker>();

builder.Services.AddSingleton(new Regex(@"restricted.*\.txt"));
builder.Services.AddSingleton<SmartTextReaderLocker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

RunDemo();

app.Run();

void RunDemo()
{
    Console.WriteLine("=== Демонстрація Smart Text Reader ===");
    
    string sampleText = "Hello World!\nЦе тестовий файл.\nВін має декілька рядків.";
    File.WriteAllText("sample.txt", sampleText);
    File.WriteAllText("restricted.txt", "Це обмежений файл.");
    
    Console.WriteLine("\n--- Оригінальний Reader ---");
    var reader = new SmartTextReader();
    var content = reader.ReadFile("sample.txt");
    PrintArray(content);
    
    Console.WriteLine("\n--- Проксі з логуванням ---");
    var loggerProxy = new SmartTextChecker(new SmartTextReader());
    content = loggerProxy.ReadFile("sample.txt");
    PrintArray(content);
    
    Console.WriteLine("\n--- Проксі з обмеженням доступу ---");
    var accessProxy = new SmartTextReaderLocker(new SmartTextReader(), new Regex(@"restricted.*\.txt"));
    
    Console.WriteLine("\nСпроба прочитати дозволений файл:");
    content = accessProxy.ReadFile("sample.txt");
    PrintArray(content);
    
    Console.WriteLine("\nСпроба прочитати обмежений файл:");
    content = accessProxy.ReadFile("restricted.txt");
    
    Console.WriteLine("\n=== Демонстрацію завершено ===");
}

void PrintArray(char[][]? array)
{
    if (array == null)
    {
        Console.WriteLine("Масив є null");
        return;
    }
    
    Console.WriteLine("Вміст як двовимірний масив:");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"Рядок {i}: [");
        for (int j = 0; j < array[i].Length; j++)
        {
            Console.Write($"'{array[i][j]}'");
            if (j < array[i].Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}

