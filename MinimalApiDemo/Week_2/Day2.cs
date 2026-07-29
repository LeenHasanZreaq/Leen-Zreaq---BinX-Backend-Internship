using System;
using System.Linq;
using System.Collections.Generic;
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



            // Grouping and Joining Data : 
            int[] numbers = { 1, 2, 3, 4, 5, 6 };

            var gro = numbers.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");
            foreach (var item in gro)
            {
                Console.WriteLine($"{item.Key} : {string.Join(", ", item)}");
            }


            var student = new List<(int id, string name)>
            {
                (1,"leen") , (2,"hasan") , (3,"zreaq")
            };

            var scores = new List<(int StudentId, int Score)>
            {
                (1, 90),
                (2, 85),
                (3, 78)
            };

            var result = student.Join(
             scores,
             s => s.id,
             sc => sc.StudentId,
             (s, sc) => new
             {
                 Name = s.name,
                 Score = sc.Score
             }
            );

            foreach (var r in result)
            {
                Console.WriteLine($"{r.Name} => {r.Score}");
            }



        }
    }
}