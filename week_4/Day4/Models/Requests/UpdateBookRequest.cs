namespace week_4.Models.Requests;

public class UpdateBookRequest
{
    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int PublishedYear { get; set; }
}