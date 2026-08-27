using MyWebProject.Data;
using MyWebProject.Models;
using Microsoft.EntityFrameworkCore;

public class TableRepository : ITableRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public TableRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RestaurantTable>> GetAllAsync() =>
        await _context.Tables.ToListAsync();

    public async Task<RestaurantTable?> GetByIdAsync(int id) =>
        await _context.Tables.FindAsync(id);

    public async Task AddAsync(RestaurantTable table)
    {
        _context.Tables.Add(table);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RestaurantTable table)
    {
        _context.Tables.Update(table);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var table = await GetByIdAsync(id);
        if (table != null)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }
    }

    Task<IEnumerable<RestaurantTable>> ITableRepository.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<RestaurantTable?> ITableRepository.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task ITableRepository.AddAsync(RestaurantTable table)
    {
        throw new NotImplementedException();
    }

    Task ITableRepository.UpdateAsync(RestaurantTable table)
    {
        throw new NotImplementedException();
    }
}
