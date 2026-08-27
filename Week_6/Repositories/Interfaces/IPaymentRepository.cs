
using MyWebProject.Models;
public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(int id);
    Task AddAsync(Payment payment);
}
