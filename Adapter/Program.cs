using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdapterPatternDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestLoggers();
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ILogger, Logger>();
            builder.Services.AddSingleton<ILogger>(provider => 
                new FileLoggerAdapter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "app.log")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

        private static void TestLoggers()
        {
            Console.WriteLine("Testing Console Logger:");
            var consoleLogger = new Logger();
            consoleLogger.Log("This is a regular log message");
            consoleLogger.Error("This is an error message");
            consoleLogger.Warn("This is a warning message");

            Console.WriteLine("\nTesting File Logger Adapter:");
            var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "test.log");
            var fileLogger = new FileLoggerAdapter(logFilePath);
            fileLogger.Log("This is a regular log message");
            fileLogger.Error("This is an error message");
            fileLogger.Warn("This is a warning message");

            Console.WriteLine($"Log file created at: {logFilePath}");
            Console.WriteLine();
        }
    }
}

