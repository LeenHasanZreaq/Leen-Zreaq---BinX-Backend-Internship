using Microsoft.EntityFrameworkCore;
using MyWebProject.week_3.Day3.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register EF Core DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
// builder.Services.AddScoped<IWeatherService, WeatherService>();
// builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();