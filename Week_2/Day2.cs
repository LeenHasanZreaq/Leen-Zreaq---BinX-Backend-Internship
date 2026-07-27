using System;

namespace test
{
    class test
    {
        // Advanced LINQ : 
        // deferred execution : 
        public static void Main(string[] args)
        {
            List<int> test = new List<int>()
            {
                0 , 1, 2 ,3 ,4
            };
            var res = test.Where(n => n > 1);

            Console.WriteLine(string.Join(", ", res));
        }
    }
}