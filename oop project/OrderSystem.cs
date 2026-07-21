using System;

namespace OrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1, "Leen", "leen@example.com");

            Order order = new Order(101, "Laptop", 2, customer);

            Invoice invoice = new Invoice(5001, order);

            OrderSummary summary = new OrderSummary(
                order.OrderId,
                order.ProductName,
                order.Quantity
            );

            Console.WriteLine("Order Summary (Record) ");
            Console.WriteLine(summary);

            Console.WriteLine();

            PrintItem(order);
            Console.WriteLine();
            PrintItem(invoice);
        }

        static void PrintItem(IPrintable item)
        {
            item.Print();
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
        private int id;
        private string name;
        private string email;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Email
        {
            get { return email; }
        }

        public Customer(int id, string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            this.id = id;
            this.name = name;
            this.email = email;
        }
    }

    // Order class
    class Order : IPrintable
    {
        private int orderId;
        private string productName;
        private int quantity;
        private Customer customer;

        public int OrderId
        {
            get { return orderId; }
        }

        public string ProductName
        {
            get { return productName; }
        }

        public int Quantity
        {
            get { return quantity; }
        }

        public Customer Customer
        {
            get { return customer; }
        }

        public Order(int orderId, string productName, int quantity, Customer customer)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be empty.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            this.orderId = orderId;
            this.productName = productName;
            this.quantity = quantity;
            this.customer = customer;
        }

        public void Print()
        {
            Console.WriteLine("=== Order ===");
            Console.WriteLine($"Order ID: {orderId}");
            Console.WriteLine($"Product: {productName}");
            Console.WriteLine($"Quantity: {quantity}");
            Console.WriteLine($"Customer: {customer.Name}");
        }
    }

    // Invoice class
    class Invoice : IPrintable
    {
        private int invoiceId;
        private Order order;

        public int InvoiceId
        {
            get { return invoiceId; }
        }

        public Order Order
        {
            get { return order; }
        }

        public Invoice(int invoiceId, Order order)
        {
            this.invoiceId = invoiceId;
            this.order = order;
        }

        public void Print()
        {
            Console.WriteLine("=== Invoice ===");
            Console.WriteLine($"Invoice ID: {invoiceId}");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"Product: {order.ProductName}");
            Console.WriteLine($"Quantity: {order.Quantity}");
        }
    }

    public record OrderSummary(int OrderId, string ProductName, int Quantity);
}