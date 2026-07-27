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
            test.Add(6);

            Console.WriteLine(string.Join(", ", res));

            // to list 
            var list_res = test.Where(n => n % 2 == 0).ToList();

            Console.WriteLine(string.Join(", ", list_res));


            // to array 
            var array_res = test.Where(n => n > 3).ToArray();
            Console.WriteLine(string.Join(", ", array_res));


            // ToDictionary :
            var dict_res = test.ToDictionary(n => n, n => n * n);
            foreach (var pair in dict_res)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }



            //Aggregation Methods 
            // count : 
            Console.WriteLine(test.Count());
            Console.WriteLine(test.Sum());
            Console.WriteLine(test.Min());
            Console.WriteLine(test.Max());
            Console.WriteLine(test.Average());
            Console.WriteLine(test.First());
            Console.WriteLine(test.Where(n => n == 4).Single());

        }
    }
}