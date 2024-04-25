using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly BankContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, BankContext bankContext)
        {

            _logger = logger;
            _context = bankContext;
        }

       
        
    }
}
