namespace WeatherApp.Models;

public class Weather
{
    public string city
    {
        get;
        set;
    } = "";


    public int temperature
    {
        get;
        set;
    }


    public string condition
    {
        get;
        set;
    } = "";
}