
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

    public async Task<Customer?> GetByIdAsync(int id) =>
        await _context.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }
}
