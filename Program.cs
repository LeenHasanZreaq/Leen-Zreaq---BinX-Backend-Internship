using MyWebProject.Services;
using week_3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();