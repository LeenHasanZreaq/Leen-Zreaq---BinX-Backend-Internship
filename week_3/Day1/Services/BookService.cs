using week_3.Models;

namespace week_3.Services;

public class BookService : IBookService
{
    private static List<Book> _book = new List<Book>();
    private static int _nextId = 1;

    public Task<List<Book>> GetAllBooksAsync()
    {
        return Task.FromResult(_book);
    }

    public Task<Book?> GetBookByIdAsync(int id)
    {
        return Task.FromResult(_book.FirstOrDefault(b => b.Id == id));
    }

    public Task<Book> CreateBookAsync(Book book)
    {
        book.Id = _nextId++;
        _book.Add(book);
        return Task.FromResult(book);
    }

    public Task<Book?> UpdateBookAsync(int id, Book book)
    {
        var existingBook = _book.FirstOrDefault(b => b.Id == id);
        if (existingBook == null) return Task.FromResult<Book?>(null);

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Price = book.Price;
        existingBook.PublishedDate = book.PublishedDate;

        return Task.FromResult<Book?>(existingBook);
    }

    public Task<bool> DeleteBookAsync(int id)
    {
        var existingBook = _book.FirstOrDefault(b => b.Id == id);
        if (existingBook == null) return Task.FromResult(false);

        _book.Remove(existingBook);
        return Task.FromResult(true);
    }
}