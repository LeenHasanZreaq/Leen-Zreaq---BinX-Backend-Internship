using MyWebProject.Models;
using MyWebProject.DTOs;
public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        _repository = repository;
    }

    // POST: Create Payment
    public async Task<PaymentResponse> CreatePaymentAsync(
        CreatePaymentRequest request)
    {
        var payment = new Payment
        {
            OrderId = request.OrderId,
            Amount = request.Amount,
            Method = request.Method,
            PaidAt = DateTime.UtcNow
        };

        await _repository.AddAsync(payment);

        return MapToResponse(payment);
    }

    // GET: Payment by ID
    public async Task<PaymentResponse?> GetPaymentAsync(int id)
    {
        var payment = await _repository.GetByIdAsync(id);

        if (payment == null)
            return null;

        return MapToResponse(payment);
    }

    // GET: All Payments
    public async Task<IEnumerable<PaymentResponse>> GetAllPaymentsAsync()
    {
        var payments = await _repository.GetAllAsync();

        return payments.Select(MapToResponse);
    }

    // GET: Payments by Order
    public async Task<IEnumerable<PaymentResponse>> GetPaymentsByOrderAsync(
        int orderId)
    {
        var payments = await _repository.GetByOrderIdAsync(orderId);

        return payments.Select(MapToResponse);
    }

    // GET: Payments by Customer
    public async Task<IEnumerable<PaymentResponse>> GetPaymentsByCustomerAsync(
        int customerId)
    {
        var payments =
            await _repository.GetByCustomerIdAsync(customerId);

        return payments.Select(MapToResponse);
    }

    // PUT: Update Payment
    public async Task<PaymentResponse?> UpdatePaymentAsync(
        int id,
        UpdatePaymentRequest request)
    {
        var payment = await _repository.GetByIdAsync(id);

        if (payment == null)
            return null;

        payment.Amount = request.Amount;
        payment.Method = request.Method;

        await _repository.UpdateAsync(payment);

        return MapToResponse(payment);
    }

    // DELETE: Delete Payment
    public async Task<bool> DeletePaymentAsync(int id)
    {
        var payment = await _repository.GetByIdAsync(id);

        if (payment == null)
            return false;

        await _repository.DeleteAsync(payment);

        return true;
    }

    // Mapping
    private static PaymentResponse MapToResponse(Payment payment)
    {
        return new PaymentResponse
        {
            Id = payment.Id,
            OrderId = payment.OrderId,
            Amount = payment.Amount,
            Method = payment.Method,
            PaidAt = payment.PaidAt
        };
    }
}
