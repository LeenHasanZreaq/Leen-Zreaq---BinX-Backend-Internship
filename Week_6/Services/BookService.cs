using MyWebProject.Models;
using MyWebProject.DTOs;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BookResponse>> GetAllBooksAsync()
    {
        var books = await _repository.GetAllAsync();
        return books.Select(b => new BookResponse
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Price = b.Price,
            PublishedDate = b.PublishedDate
        });
    }

    public async Task<BookResponse?> GetBookByIdAsync(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        if (book == null) return null;

        return new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            PublishedDate = book.PublishedDate
        };
    }

    public async Task<BookResponse> CreateBookAsync(CreateBookRequest request)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Price = request.Price,
            PublishedDate = request.PublishedDate
        };

        await _repository.AddAsync(book);

        return new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            PublishedDate = book.PublishedDate
        };
    }

    public async Task<BookResponse?> UpdateBookAsync(int id, CreateBookRequest request)
    {
        var book = await _repository.GetByIdAsync(id);
        if (book == null) return null;

        book.Title = request.Title;
        book.Author = request.Author;
        book.Price = request.Price;
        book.PublishedDate = request.PublishedDate;

        await _repository.UpdateAsync(book);

        return new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            PublishedDate = book.PublishedDate
        };
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        if (book == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}
