using System;
using System.Text.RegularExpressions;

public class SmartTextReaderLocker : ISmartTextReader
{
    private readonly ISmartTextReader _reader;
    private readonly Regex _restrictedPattern;
    
    public SmartTextReaderLocker(ISmartTextReader reader, Regex restrictedPattern)
    {
        _reader = reader;
        _restrictedPattern = restrictedPattern;
    }
    
    public char[][]? ReadFile(string filePath)
    {
        if (_restrictedPattern.IsMatch(filePath))
        {
            Console.WriteLine("Доступ заборонено!");
            return null;
        }
        
        return _reader.ReadFile(filePath);
    }
}

