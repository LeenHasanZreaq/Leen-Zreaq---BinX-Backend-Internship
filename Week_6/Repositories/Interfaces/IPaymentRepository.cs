using MyWebProject.Models;

public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(int id);

    Task<IEnumerable<Payment>> GetAllAsync();

    Task<IEnumerable<Payment>> GetByOrderIdAsync(int orderId);

    Task<IEnumerable<Payment>> GetByCustomerIdAsync(int customerId);

    Task AddAsync(Payment payment);

    Task UpdateAsync(Payment payment);

    Task DeleteAsync(Payment payment);
}
