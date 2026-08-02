namespace week_3.DTOs;

public class CreateBookDto
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishedDate { get; set; }
}
