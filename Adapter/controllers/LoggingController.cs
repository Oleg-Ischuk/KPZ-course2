using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdapterPatternDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingController : ControllerBase
    {
        private readonly IEnumerable<ILogger> _loggers;

        public LoggingController(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers;
        }

        [HttpGet("log")]
        public IActionResult Log(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(message);
            }
            return Ok("Message logged");
        }

        [HttpGet("error")]
        public IActionResult Error(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Error(message);
            }
            return Ok("Error logged");
        }

        [HttpGet("warn")]
        public IActionResult Warn(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Warn(message);
            }
            return Ok("Warning logged");
        }
    }
}

