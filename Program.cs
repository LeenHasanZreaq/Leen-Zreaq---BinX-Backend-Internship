using MyWebProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();