using System;
using System.Threading;

namespace Async
{
    public class UserService
    {

        public string GetUserProfile(string userId)
        {
            Thread.Sleep(2000);
            return $"profile of user{userId}";
        }

        public string GetOrderHistory(string userId)
        {
            Thread.Sleep(2000);
            return $"order of user{userId}";
        }
        public static void Main(string[] args)
        {
            var service = new UserService();
            var start = DateTime.Now;

            string profile = service.GetUserProfile("101");
            string orders = service.GetOrderHistory("101");

            Console.WriteLine(profile);
            Console.WriteLine(orders);
            Console.WriteLine($"total time : {(DateTime.Now - start).TotalMicroseconds}");
        }


    }
}