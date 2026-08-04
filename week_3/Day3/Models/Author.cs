namespace MyWebProject.week_3.Day3.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new();
    }
}