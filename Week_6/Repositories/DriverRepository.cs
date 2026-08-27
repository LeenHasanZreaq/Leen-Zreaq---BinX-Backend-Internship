using MyWebProject.Data;
using MyWebProject.Models;
using Microsoft.EntityFrameworkCore;
public class DriverRepository : IDriverRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public DriverRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Driver>> GetAllAsync() =>
        await _context.Drivers.ToListAsync();

    public async Task<Driver?> GetByIdAsync(int id) =>
        await _context.Drivers.FindAsync(id);

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

    Task<IEnumerable<Driver>> IDriverRepository.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<Driver?> IDriverRepository.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task IDriverRepository.AddAsync(Driver driver)
    {
        throw new NotImplementedException();
    }

    Task IDriverRepository.UpdateAsync(Driver driver)
    {
        throw new NotImplementedException();
    }
}
