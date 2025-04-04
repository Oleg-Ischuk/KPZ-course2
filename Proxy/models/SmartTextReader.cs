using System;
using System.IO;

public class SmartTextReader : ISmartTextReader
{
    public char[][]? ReadFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            
            char[][] result = new char[lines.Length][];
            
            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }
            
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка читання файлу: {ex.Message}");
            return null;
        }
    }
}

