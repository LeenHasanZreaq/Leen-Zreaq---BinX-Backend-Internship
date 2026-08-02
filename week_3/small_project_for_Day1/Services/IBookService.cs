using week_3.Models;
namespace week_3.Services;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> CreateBookAsync(Book book);
    Task<Book?> UpdateBookAsync(int id, Book book);
    Task<bool> DeleteBookAsync(int id);
}