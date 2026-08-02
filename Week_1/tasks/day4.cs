using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create Customers
            Customer c1 = new Customer(1, "Leen", "leen@example.com");
            Customer c2 = new Customer(2, "Ahmad", "ahmad@example.com");
            Customer c3 = new Customer(3, "Sara", "sara@example.com");
            Customer c4 = new Customer(4, "Omar", "omar@example.com");
            Customer c5 = new Customer(5, "Noor", "noor@example.com");
            Customer c6 = new Customer(6, "Ali", "ali@example.com");
            Customer c7 = new Customer(7, "Hala", "hala@example.com");
            Customer c8 = new Customer(8, "Yousef", "yousef@example.com");

            // Create Orders (8 objects)
            List<Order> orders = new List<Order>
            {
                new Order(101, "Laptop", 2, c1),
                new Order(102, "Phone", 1, c2),
                new Order(103, "Tablet", 3, c3),
                new Order(104, "Monitor", 5, c4),
                new Order(105, "Keyboard", 10, c5),
                new Order(106, "Mouse", 7, c6),
                new Order(107, "Smartwatch", 4, c7),
                new Order(108, "Headphones", 6, c8)
            };

            // LINQ Queries
            var largeOrders = orders.Where(o => o.Quantity > 5); // Filter
            var productNames = orders.Select(o => o.ProductName); // Projection
            var totalQuantity = orders.Sum(o => o.Quantity); // Aggregation

            Console.WriteLine("=== LINQ Results ===");
            Console.WriteLine("Large Orders (Quantity > 5):");
            foreach (var order in largeOrders)
                Console.WriteLine($"Order {order.OrderId}: {order.ProductName} x{order.Quantity}");

            Console.WriteLine("\nProduct Names:");
            foreach (var name in productNames)
                Console.WriteLine(name);

            Console.WriteLine($"\nTotal Quantity of All Orders: {totalQuantity}");

            // Async Method Example
            string asyncResult = await LoadDataAsync();
            Console.WriteLine($"\nAsync Result: {asyncResult}");

            // Try/Catch Example
            try
            {
                Console.WriteLine("\nEnter a number:");
                string input = Console.ReadLine();
                int number = int.Parse(input); // risky operation
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }

        // Async Method
        public static async Task<string> LoadDataAsync()
        {
            await Task.Delay(2000); // simulate I/O delay
            return "Data loaded successfully!";
        }
    }

    // Interface
    interface IPrintable
    {
        void Print();
    }

    // Customer class
    class Customer
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }

        public Customer(int id, string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            Id = id;
            Name = name;
            Email = email;
        }
    }

    // Order class
    class Order : IPrintable
    {
        public int OrderId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public Customer Customer { get; }

        public Order(int orderId, string productName, int quantity, Customer customer)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be empty.");
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Customer = customer;
        }

        public void Print()
        {
            Console.WriteLine("=== Order ===");
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Product: {ProductName}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Customer: {Customer.Name}");
        }
    }

    // Invoice class
    class Invoice : IPrintable
    {
        public int InvoiceId { get; }
        public Order Order { get; }

        public Invoice(int invoiceId, Order order)
        {
            InvoiceId = invoiceId;
            Order = order;
        }

        public void Print()
        {
            Console.WriteLine("=== Invoice ===");
            Console.WriteLine($"Invoice ID: {InvoiceId}");
            Console.WriteLine($"Customer: {Order.Customer.Name}");
            Console.WriteLine($"Product: {Order.ProductName}");
            Console.WriteLine($"Quantity: {Order.Quantity}");
        }
    }

    // Record
    public record OrderSummary(int OrderId, string ProductName, int Quantity);
}
