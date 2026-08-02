using Microsoft.AspNetCore.Mvc;
using MyWebProject.Services;
using WeatherApp.DTOs;

namespace MyWebProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService weatherService1;

    public WeatherController(IWeatherService weatherService)
    {
        weatherService1 = weatherService;
    }

    [HttpPost]

    public IActionResult GetWeather(WeatherDTO dto)
    {
        var res = weatherService1.GetWeather(dto.city);

        return Ok(res);
    }
}