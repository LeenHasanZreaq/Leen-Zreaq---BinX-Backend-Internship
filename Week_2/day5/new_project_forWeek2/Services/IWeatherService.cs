using WeatherApp.Week2.Models;

namespace MyWebProject.Services;

public interface IWeatherService
{
    Weather GetWeather(string city);
}