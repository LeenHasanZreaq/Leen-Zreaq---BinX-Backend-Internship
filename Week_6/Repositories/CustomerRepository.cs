using Microsoft.EntityFrameworkCore;
using MyWebProject.Data;
using MyWebProject.Models;

public class CustomerRepository : ICustomerRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public CustomerRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    // ========================================
    // Get Customer By ID
    // ========================================

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // ========================================
    // Get All Customers
    // ========================================

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers
            .Include(c => c.Orders)
            .ToListAsync();
    }

    // ========================================
    // Create Customer
    // ========================================

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    // ========================================
    // Update Customer
    // ========================================

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    // ========================================
    // Delete Customer
    // ========================================

    public async Task DeleteAsync(Customer customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}