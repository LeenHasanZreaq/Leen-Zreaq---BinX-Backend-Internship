using WeatherApp.Models;

namespace MyWebProject.Services;

public class WeatherService : IWeatherService
{
    public Weather GetWeather(string city)
    {
        // fake data to test

        return new Weather
        {
            city = city,
            temperature = 25,
            condition = "Sunny"
        };
    }
}