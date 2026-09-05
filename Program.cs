using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using MyWebProject.Data;
using MyWebProject.Mapping;
using MyWebProject.Week_6.Services;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// Controllers
// ========================================

builder.Services.AddControllers();

// ========================================
// Database
// ========================================

builder.Services.AddDbContext<PizzaRestaurantDbContext>(options =>
{
    options.UseInMemoryDatabase("PizzaRestaurantDb");
});

// ========================================
// AutoMapper
// ========================================

builder.Services.AddAutoMapper(typeof(MappingProfile));

// ========================================
// Repositories
// ========================================

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IKitchenRepository, KitchenRepository>();
builder.Services.AddScoped<IDeliveryCompanyRepository, DeliveryCompanyRepository>();

// ========================================
// Services
// ========================================

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IKitchenService, KitchenService>();
builder.Services.AddScoped<IDeliveryCompanyService, DeliveryCompanyService>();

// ========================================
// Authentication / JWT
// ========================================

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();

var jwtKey = builder.Configuration["Jwt:Key"];

if (string.IsNullOrWhiteSpace(jwtKey))
{
    jwtKey = "Week6DevelopmentSecretKey_ChangeThis_AtLeast32Characters!";
}

var jwtIssuer = builder.Configuration["Jwt:Issuer"]
                ?? "PizzaRestaurantAPI";

var jwtAudience = builder.Configuration["Jwt:Audience"]
                  ?? "PizzaRestaurantClients";

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            ),

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

// ========================================
// Swagger
// ========================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ========================================
// Build
// ========================================

var app = builder.Build();

// ========================================
// Swagger
// ========================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ========================================
// Authentication & Authorization
// ========================================

app.UseAuthentication();
app.UseAuthorization();

// ========================================
// Controllers
// ========================================

app.MapControllers();

// ========================================
// Database Seeder
// ========================================

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<PizzaRestaurantDbContext>();

    DbSeeder.Seed(db);
}

// ========================================
// Run
// ========================================

app.Run();

public partial class Program { }