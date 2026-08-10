using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyWebProject.week_3.Day4.Data;

var builder = WebApplication.CreateBuilder(args);

// Controllers

builder.Services.AddControllers();


// Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Database

builder.Services.AddDbContext<Day4DbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});


// ASP.NET Core Identity

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<Day4DbContext>()
    .AddDefaultTokenProviders();


// JWT Authentication

var key = Encoding.UTF8.GetBytes(
    builder.Configuration["Jwt:Key"]!
);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Validate JWT issuer
            ValidateIssuer = true,

            // Validate JWT audience
            ValidateAudience = true,

            // Validate token expiration
            ValidateLifetime = true,

            // Validate signature
            ValidateIssuerSigningKey = true,

            // Issuer
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            // Audience
            ValidAudience = builder.Configuration["Jwt:Audience"],

            // Secret key
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });


// Authorization

builder.Services.AddAuthorization();


// Build App

var app = builder.Build();


// Swagger

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(
        "/swagger/v1/swagger.json",
        "Week 4 Identity API V1"
    );

    c.RoutePrefix = string.Empty;
});


// Middleware

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


// Controllers

app.MapControllers();

app.Run();
