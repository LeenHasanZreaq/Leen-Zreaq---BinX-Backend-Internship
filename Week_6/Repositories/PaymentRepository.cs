using MyWebProject.Data;
using MyWebProject.Models;

public class PaymentRepository : IPaymentRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public PaymentRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<Payment?> GetByIdAsync(int id) =>
        await _context.Payments.FindAsync(id);

    public async Task AddAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }

    Task<Payment?> IPaymentRepository.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task IPaymentRepository.AddAsync(Payment payment)
    {
        throw new NotImplementedException();
    }
}
