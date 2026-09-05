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

    public async Task<Payment?> GetByIdAsync(int id)
    {
        return await _context.Payments
            .Include(p => p.Order)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }
}
