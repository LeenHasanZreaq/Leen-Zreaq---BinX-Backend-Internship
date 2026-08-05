using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebProject.week_3.Day4.Data;
using MyWebProject.week_3.Day4.Models;

namespace MyWebProject.week_3.Day4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly Day4DbContext _context;

    public BooksController(Day4DbContext context)
    {
        _context = context;
    }

    // GET 

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return Ok(await _context.Books.ToListAsync());
    }

    // GET BY ID

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    // CREATE

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book)
    {
        _context.Books.Add(book);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetBook),
            new { id = book.Id },
            book);
    }

    // UPDATE

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.Price = updatedBook.Price;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return NotFound();

        _context.Books.Remove(book);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}