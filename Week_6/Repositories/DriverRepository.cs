using Microsoft.EntityFrameworkCore;
using MyWebProject.Data;
using MyWebProject.Models;

public class DriverRepository : IDriverRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public DriverRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Driver>> GetAllAsync()
    {
        return await _context.Drivers.ToListAsync();
    }

    public async Task<Driver?> GetByIdAsync(int id)
    {
        return await _context.Drivers.FindAsync(id);
    }

    public async Task AddAsync(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Driver driver)
    {
        _context.Drivers.Update(driver);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Driver driver)
    {
        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
    }
}