using MyWebProject.Models;

namespace MyWebProject.Data
{
    public static class DbSeeder
    {
        public static void Seed(PizzaRestaurantDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Pizza" },
                    new Category { Name = "Drinks" },
                    new Category { Name = "Desserts" }
                );
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var pizzaCategory = context.Categories.First(c => c.Name == "Pizza");
                var drinksCategory = context.Categories.First(c => c.Name == "Drinks");

                context.Products.AddRange(
                    new Product { Name = "Margherita", Brand = "Classic", Price = 25, CategoryId = pizzaCategory.Id },
                    new Product { Name = "Pepperoni", Brand = "Spicy", Price = 30, CategoryId = pizzaCategory.Id },
                    new Product { Name = "Coca Cola", Brand = "Coca Cola", Price = 5, CategoryId = drinksCategory.Id }
                );
                context.SaveChanges();
            }

            if (!context.Tables.Any())
            {
                context.Tables.AddRange(
                    new RestaurantTable { Number = 1, Capacity = 4 },
                    new RestaurantTable { Number = 2, Capacity = 2 },
                    new RestaurantTable { Number = 3, Capacity = 6 }
                );
                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    FullName = "Sample Customer",
                    Phone = "+966500000000",
                    Address = "Riyadh"
                });
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                var customer = context.Customers.First();
                var table = context.Tables.First();

                context.Orders.Add(new Order
                {
                    CustomerId = customer.Id,
                    TableId = table.Id,
                    Status = "Ready",
                    CreatedAt = DateTime.UtcNow
                });
                context.SaveChanges();
            }

            if (!context.Notifications.Any())
            {
                var table = context.Tables.First();

                context.Notifications.Add(new TableNotification
                {
                    TableId = table.Id,
                    Message = "Your table is ready for pickup.",
                    IsRead = false
                });
                context.SaveChanges();
            }
        }
    }
}
