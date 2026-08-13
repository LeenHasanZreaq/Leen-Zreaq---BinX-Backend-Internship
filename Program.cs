using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyWebProject.week_3.Day4.Data;
using System.Text;

using FluentValidation;
using FluentValidation.AspNetCore;
using week_4.Validators;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookRequestValidator>();

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

// JWT
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is missing.");

var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultChallengeScheme =
            JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

// Authorization + Policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanManageBooks", policy =>
    {
        policy.RequireClaim("permission", "ManageBooks");
    });
});


// CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("https://myapp.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// RATE LIMITING

builder.Services.AddRateLimiter(options =>
{
    // General endpoints
    options.AddFixedWindowLimiter("general", limiterOptions =>
    {
        limiterOptions.PermitLimit = 100;

        limiterOptions.Window =
            TimeSpan.FromMinutes(1);

        limiterOptions.QueueLimit = 0;
    });

    // Login endpoint
    options.AddFixedWindowLimiter("login", limiterOptions =>
    {
        limiterOptions.PermitLimit = 5;

        limiterOptions.Window =
            TimeSpan.FromMinutes(1);

        limiterOptions.QueueLimit = 0;
    });

    options.RejectionStatusCode =
        StatusCodes.Status429TooManyRequests;
});


var app = builder.Build();


// Swagger

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Week 4 API V1"
        );

        c.RoutePrefix = string.Empty;
    });
}


// HTTPS

app.UseHttpsRedirection();


// HSTS

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


// SECURITY HEADERS

app.Use(async (context, next) =>
{
    context.Response.Headers["X-Content-Type-Options"] =
        "nosniff";

    context.Response.Headers["X-Frame-Options"] =
        "DENY";

    context.Response.Headers["Content-Security-Policy"] =
        "default-src 'self'";

    await next();
});


// CORS

app.UseCors("AllowFrontend");


// RATE LIMITING

app.UseRateLimiter();


// AUTHENTICATION

app.UseAuthentication();


// AUTHORIZATION

app.UseAuthorization();


// Seed Roles + Test Users

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

    var userManager = scope.ServiceProvider
        .GetRequiredService<UserManager<IdentityUser>>();

    // Create roles
    string[] roles = { "User", "Admin" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(
                new IdentityRole(role)
            );
        }
    }

    // Create normal user
    var normalUser = await userManager
        .FindByEmailAsync("user@test.com");

    if (normalUser == null)
    {
        normalUser = new IdentityUser
        {
            UserName = "user@test.com",
            Email = "user@test.com",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(
            normalUser,
            "User123!"
        );

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(
                normalUser,
                "User"
            );
        }
    }

    // Create admin
    var adminUser = await userManager
        .FindByEmailAsync("admin@test.com");

    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = "admin@test.com",
            Email = "admin@test.com",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(
            adminUser,
            "Admin123!"
        );

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(
                adminUser,
                "Admin"
            );
        }
    }
}


// Controllers

app.MapControllers();

app.Run();