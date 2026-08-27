using MyWebProject.Models;

public interface IDriverRepository
{
    Task<IEnumerable<Driver>> GetAllAsync();
    Task<Driver?> GetByIdAsync(int id);
    Task AddAsync(Driver driver);
    Task UpdateAsync(Driver driver);
}
