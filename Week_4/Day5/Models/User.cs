namespace MyWebProject.Models;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public ICollection<Note> Notes { get; set; } = new List<Note>();
}