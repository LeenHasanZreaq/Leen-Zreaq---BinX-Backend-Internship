using WeatherApp.Models;

namespace MyWebProject.Services;

public interface IWeatherService
{
    Weather GetWeather(string city);
}