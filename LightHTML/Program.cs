using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using LightHTML.Models;
using LightHTML.Controllers;

namespace LightHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LightHTML Text to HTML Converter");
            Console.WriteLine("=================================");

            // Створюємо екземпляр контролера HTML-будівельника
            var htmlBuilder = new HtmlBuilderController();
            string bookPath = "book.txt";
            
            if (!File.Exists(bookPath))
            {
                Console.WriteLine($"Файл {bookPath} не знайдено. Будь ласка, створіть цей файл з текстом книги.");
                Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
                Console.ReadKey();
                return;
            }
            
            string bookText = File.ReadAllText(bookPath);
            string[] lines = bookText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            Console.WriteLine($"Загальна кількість рядків у книзі: {lines.Length}");

            // Створюємо HTML-документ без використання патерну Легковаговик
            Console.WriteLine("\nСтворення HTML-документа без патерну Легковаговик...");
            var memoryBefore = GC.GetTotalMemory(true);
            var stopwatch = Stopwatch.StartNew();
            
            var documentWithoutFlyweight = htmlBuilder.CreateHtmlDocumentWithoutFlyweight(lines);
            
            stopwatch.Stop();
            var memoryAfter = GC.GetTotalMemory(true);
            
            Console.WriteLine($"Використано пам'яті без Легковаговика: {(memoryAfter - memoryBefore) / 1024} KB");
            Console.WriteLine($"Час виконання: {stopwatch.ElapsedMilliseconds} мс");
            Console.WriteLine($"Загальна кількість вузлів: {documentWithoutFlyweight.ChildCount}");

            // Створюємо HTML-документ з використанням патерну Легковаговик
            Console.WriteLine("\nСтворення HTML-документа з патерном Легковаговик...");
            memoryBefore = GC.GetTotalMemory(true);
            stopwatch.Restart();
            
            var documentWithFlyweight = htmlBuilder.CreateHtmlDocumentWithFlyweight(lines);
            
            stopwatch.Stop();
            memoryAfter = GC.GetTotalMemory(true);
            
            Console.WriteLine($"Використано пам'яті з Легковаговиком: {(memoryAfter - memoryBefore) / 1024} KB");
            Console.WriteLine($"Час виконання: {stopwatch.ElapsedMilliseconds} мс");
            Console.WriteLine($"Загальна кількість вузлів: {documentWithFlyweight.ChildCount}");
            Console.WriteLine($"Унікальних текстових вузлів у фабриці Легковаговика: {TextNodeFlyweightFactory.Instance.Count}");

            // Зберігаємо HTML-вивід у файл
            string outputPath = "romeo_and_juliet.html";
            File.WriteAllText(outputPath, documentWithFlyweight.RenderOuterHTML());
            Console.WriteLine($"\nHTML-вивід збережено у файл: {outputPath}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}