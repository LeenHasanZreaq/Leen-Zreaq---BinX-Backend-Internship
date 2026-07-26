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
    }
}