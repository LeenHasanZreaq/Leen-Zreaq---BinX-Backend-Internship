using System;
using System.Collections.Generic;
// Generics and advanced collections 
namespace Week2
{
    class Day1
    {

        private Dictionary<string, List<string>> bookByAuthor = new Dictionary<string, List<string>>();
        public static void Main(String[] args)
        {
            Day1 day = new Day1();
            day.AddBook("arabic", "The Hobbit");

            Console.WriteLine(string.Join(", ", day.GetBookBy("arabic")));
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
}