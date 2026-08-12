using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using week_3.Models;
using week_3.Services;
using week_4.Models.Requests;

namespace week_3.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // Any authenticated user
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();

        return Ok(books);
    }

    // Any authenticated user
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    // Policy required
    [Authorize(Policy = "CanManageBooks")]
    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(
        CreateBookRequest request)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Price = request.Price,
            PublishedYear = request.PublishedYear
        };

        var createdBook =
            await _bookService.CreateBookAsync(book);

        return CreatedAtAction(
            nameof(GetBook),
            new { id = createdBook.Id },
            createdBook
        );
    }

    // Any authenticated user
    [HttpPut("{id}")]
    public async Task<ActionResult<Book>> UpdateBook(
        int id,
        UpdateBookRequest request)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Price = request.Price,
            PublishedYear = request.PublishedYear
        };

        var updatedBook =
            await _bookService.UpdateBookAsync(id, book);

        if (updatedBook == null)
            return NotFound();

        return Ok(updatedBook);
    }

    // Admin only
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var success =
            await _bookService.DeleteBookAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}