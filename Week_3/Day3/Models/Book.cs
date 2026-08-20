namespace MyWebProject.week_3.Day3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}