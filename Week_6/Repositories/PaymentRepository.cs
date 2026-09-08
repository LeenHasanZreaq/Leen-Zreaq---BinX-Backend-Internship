using Microsoft.EntityFrameworkCore;
using MyWebProject.Data;
using MyWebProject.Models;

public class PaymentRepository : IPaymentRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public PaymentRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    // GET: Payment by ID
    public async Task<Payment?> GetByIdAsync(int id)
    {
        return await _context.Payments
            .Include(p => p.Order)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    // GET: All Payments
    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await _context.Payments
            .Include(p => p.Order)
            .ToListAsync();
    }

    // GET: Payments by Order
    public async Task<IEnumerable<Payment>> GetByOrderIdAsync(int orderId)
    {
        return await _context.Payments
            .Include(p => p.Order)
            .Where(p => p.OrderId == orderId)
            .ToListAsync();
    }

    // GET: Payments by Customer
    public async Task<IEnumerable<Payment>> GetByCustomerIdAsync(int customerId)
    {
        return await _context.Payments
            .Include(p => p.Order)
            .Where(p => p.Order.CustomerId == customerId)
            .ToListAsync();
    }

    // POST: Create Payment
    public async Task AddAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }

    // PUT: Update Payment
    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }

    // DELETE: Delete Payment
    public async Task DeleteAsync(Payment payment)
    {
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }
}
