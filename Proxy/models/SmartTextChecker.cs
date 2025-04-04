using System;

public class SmartTextChecker : ISmartTextReader
{
    private readonly ISmartTextReader _reader;
    
    public SmartTextChecker(ISmartTextReader reader)
    {
        _reader = reader;
    }
    
    public char[][]? ReadFile(string filePath)
    {
        Console.WriteLine($"[ЖУРНАЛ] Відкриття файлу: {filePath}");
        
        var result = _reader.ReadFile(filePath);
        
        Console.WriteLine("[ЖУРНАЛ] Файл успішно прочитано");
        
        if (result != null)
        {
            int lineCount = result.Length;
            int charCount = 0;
            
            for (int i = 0; i < result.Length; i++)
            {
                charCount += result[i].Length;
            }
            
            Console.WriteLine($"[ЖУРНАЛ] Загальна кількість рядків: {lineCount}");
            Console.WriteLine($"[ЖУРНАЛ] Загальна кількість символів: {charCount}");
        }
        
        Console.WriteLine("[ЖУРНАЛ] Файл закрито");
        
        return result;
    }
}

