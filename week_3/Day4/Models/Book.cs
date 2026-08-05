using System.ComponentModel.DataAnnotations;

namespace MyWebProject.week_3.Day4.Models;


public class Book
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Author { get; set; } = string.Empty;

    [Range(1, 1000)]
    public decimal Price { get; set; }
}