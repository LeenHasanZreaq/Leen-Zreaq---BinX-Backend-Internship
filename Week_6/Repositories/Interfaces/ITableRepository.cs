
using MyWebProject.Models;
public interface ITableRepository
{
    Task<IEnumerable<RestaurantTable>> GetAllAsync();
    Task<RestaurantTable?> GetByIdAsync(int id);
    Task AddAsync(RestaurantTable table);
    Task UpdateAsync(RestaurantTable table);
    Task DeleteAsync(int id);
}
