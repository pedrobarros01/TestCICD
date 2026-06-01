using Microsoft.AspNetCore.Mvc;

namespace FiapApIDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];
        private static readonly string[] Countries = ["Brasil", "Argentina", "Panama", "Alemanha"];
        [HttpGet("pegar-clima-paises")]
        public IEnumerable<Weather> GetWeatherCountries()
        {
            var rng = new Random();
            var response = new List<Weather>();
            foreach (var s in Countries)
            {
                var temperature = rng.Next(0, 35);
                response.Add(new Weather
                {
                    Pais = s,
                    Data = DateTime.Now,
                    TemperatureC = temperature,
                    Resumo = ObterResumo(temperature)
                });
            }
            return response;
        }
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        private static string ObterResumo(int temperaturaC)
        {

            return temperaturaC switch
            {

                var temp when temp < 0 => "Congelante",
                var temp when temp < 10 => "Frio",
                var temp when temp < 15 => "Frio agradavel",
                var temp when temp < 20 => "Agradável",
                var temp when temp < 25 => "Moderado",
                var temp when temp < 30 => "Quente",
                _ => "Muito Quente",
            };
        }
    }
}
