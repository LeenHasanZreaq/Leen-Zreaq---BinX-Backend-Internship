using System;
using System.Collections.Generic;
// Generics and advanced collections 
namespace Week2
{
    // 1.1 , 1.2 => done .
    // 1.3 => done .
    // 1.4 => 
    class Day1
    {

        private Dictionary<string, List<string>> bookByAuthor = new Dictionary<string, List<string>>();
        public static void Main(String[] args)
        {
            Day1 day = new Day1();
            day.AddBook("arabic", "The Hobbit");

            Console.WriteLine(string.Join(", ", day.GetBookBy("arabic")));


            GradeBook<int> grades = new GradeBook<int>();
            grades.AddScore(85);
            grades.AddScore(92);
            grades.AddScore(70);
            grades.AddScore(88);

            Console.WriteLine("Highest: " + grades.GetHighestScore());
            Console.WriteLine("Lowest: " + grades.GetLowestScore());


            Console.WriteLine("........................................");
            Choosing chooser = new Choosing();
            chooser.PrintAll(new List<string> { "a", "b", "c" });

            Console.WriteLine("........................................");

            List<string> names = new List<string> { "ahmad", "Sara" };
            chooser.AddIfMissing(names, "leen");
            Console.WriteLine(string.Join(", ", names));

            List<string> items = new List<string> { "apple", "banana", "cherry" };
            Console.WriteLine("........................................");
            string second = chooser.GetSecondItem(items);
            Console.WriteLine(second);


            Dictionary<string, int> data = new Dictionary<string, int>()
            {
                { "ahmad", 90 },
                { "Sara", 85 },
                { "Omar", 70 }
            };

            chooser.PrintDictionary(data);


            HashSet<int> a = new HashSet<int> { 1, 2, 3 };
            HashSet<int> b = new HashSet<int> { 3, 4, 5 };

            chooser.ShowUnion(a, b);

        }

        public void AddBook(string author, string title)
        {
            if (!bookByAuthor.ContainsKey((author)))
            {
                bookByAuthor[author] = new List<string>();
            }
            bookByAuthor[author].Add(title);
        }

        public List<string> GetBookBy(string author)
        {
            return bookByAuthor.TryGetValue(author, out var books) ? books : new List<string>();
        }

    }

    public class GradeBook<T> where T : IComparable<T>
    {

        private List<T> score = new List<T>();
        public void AddScore(T scorest)
        {
            score.Add(scorest);
        }

        public T GetHighestScore()
        {
            T highest = score[0];

            foreach (var scores in score)
            {
                if (scores.CompareTo(highest) > 0)
                {
                    highest = scores;
                }
            }
            return highest;
        }


        public T GetLowestScore()
        {
            T lowest = score[0];

            foreach (var scores in score)
            {
                if (scores.CompareTo(lowest) < 0)
                {
                    lowest = scores;
                }
            }
            return lowest;
        }
    }



    public class Choosing
    {
        // IEnumerable , ICollection , IDictionary<TKey, TValue> , IList<T> . ISet<T> , IReadOnlyList<T> .

        public void PrintAll(IEnumerable<string> item)
        {
            foreach (var items in item)
            {
                Console.WriteLine(items);
            }
        }

        public void AddIfMissing(ICollection<string> item, string newItem)
        {
            if (!item.Contains(newItem))
            {
                item.Add(newItem);
            }
            Console.WriteLine("all : " + item.Count);
        }

        public string GetSecondItem(IList<string> item)
        {
            return item[1];
        }


        public void PrintDictionary(IDictionary<string, int> item)
        {
            foreach (var pair in item)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }

        public void ShowUnion(ISet<int> a, ISet<int> b)
        {
            a.UnionWith(b);
            Console.WriteLine(string.Join(", ", a));
        }
    }
}