using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedLINQ
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }

        public List<string> Items { get; set; } = new List<string>();
    }

    class Program
    {
        static void Main(string[] args)
        {


            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Leen" },
                new Customer { Id = 2, Name = "Ahmad" },
                new Customer { Id = 3, Name = "Sara" },
                new Customer { Id = 4, Name = "Omar" },
                new Customer { Id = 5, Name = "Lina" },
                new Customer { Id = 6, Name = "yazan" }
            };

            List<Order> orders = new List<Order>
            {
                new Order
                {
                    Id = 101,
                    CustomerId = 1,
                    Amount = 150,
                    Items = new List<string>{"Keyboard","Mouse"}
                },

                new Order
                {
                    Id = 102,
                    CustomerId = 2,
                    Amount = 250,
                    Items = new List<string>{"Monitor"}
                },

                new Order
                {
                    Id = 103,
                    CustomerId = 1,
                    Amount = 100,
                    Items = new List<string>{"USB","Headphones"}
                },

                new Order
                {
                    Id = 104,
                    CustomerId = 3,
                    Amount = 300,
                    Items = new List<string>{"Laptop"}
                },

                new Order
                {
                    Id = 105,
                    CustomerId = 4,
                    Amount = 120,
                    Items = new List<string>{"Webcam","Microphone"}
                },

                new Order
                {
                    Id = 106,
                    CustomerId = 5,
                    Amount = 180,
                    Items = new List<string>{"SSD"}
                }
            };


            Console.WriteLine("GroupBy : ");

            var groupResult = orders
                .GroupBy(o => o.CustomerId)
                .Select(g => new
                {
                    CustomerId = g.Key,
                    TotalAmount = g.Sum(o => o.Amount)
                });

            foreach (var g in groupResult)
            {
                Console.WriteLine($"Customer {g.CustomerId} : {g.TotalAmount}");
            }



            Console.WriteLine("\n Join :");

            var joinResult = customers.Join(
                orders,
                customer => customer.Id,
                order => order.CustomerId,
                (customer, order) => new
                {
                    customer.Name,
                    order.Amount
                });

            foreach (var item in joinResult)
            {
                Console.WriteLine($"{item.Name} -> {item.Amount}");
            }


            Console.WriteLine("\n SelectMany :");

            var allItems = orders.SelectMany(order => order.Items);

            foreach (var item in allItems)
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("\n Deferred Execution :");

            List<int> numbers = new List<int>
            {
                1,2,3,4,5
            };

            var query = numbers.Where(n => n > 2);

            numbers.Add(10);

            Console.WriteLine("Query Result:");

            foreach (var n in query)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("\nUsing ToList():");

            var list = numbers.Where(n => n > 2).ToList();

            numbers.Add(20);

            foreach (var n in list)
            {
                Console.WriteLine(n);
            }
        }
    }
}