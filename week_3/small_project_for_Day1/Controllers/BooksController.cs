using Microsoft.AspNetCore.Mvc;
using week_3.Models;
using week_3.Services;

namespace week_3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book)
    {
        var createdBook = await _bookService.CreateBookAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
    {
        var updatedBook = await _bookService.UpdateBookAsync(id, book);
        if (updatedBook == null)
            return NotFound();

        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var success = await _bookService.DeleteBookAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}
