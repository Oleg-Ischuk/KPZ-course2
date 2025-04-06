using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

[ApiController]
[Route("api/[controller]")]
public class TextReaderController : ControllerBase
{
    private readonly ISmartTextReader _reader;
    private readonly SmartTextChecker _loggerProxy;
    private readonly SmartTextReaderLocker _accessProxy;
    
    public TextReaderController(
        ISmartTextReader reader,
        SmartTextChecker loggerProxy,
        SmartTextReaderLocker accessProxy) 
    {
        _reader = reader;
        _loggerProxy = loggerProxy;
        _accessProxy = accessProxy;
    }
    
    [HttpGet("read")]
    public IActionResult ReadFile(string filePath, string proxyType = "none")
    {
        char[][]? result;
        
        switch (proxyType.ToLower())
        {
            case "logger":
                result = _loggerProxy.ReadFile(filePath);
                break;
            case "access":
                result = _accessProxy.ReadFile(filePath);
                break;
            default:
                result = _reader.ReadFile(filePath);
                break;
        }
        
        if (result == null)
        {
            return BadRequest("Failed to read file or access denied");
        }
        
        var response = new
        {
            Lines = result.Select(line => new string(line)).ToArray()
        };
        
        return Ok(response);
    }
}

