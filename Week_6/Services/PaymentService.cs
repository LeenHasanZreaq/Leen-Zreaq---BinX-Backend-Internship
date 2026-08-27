using MyWebProject.Models;
using MyWebProject.DTOs;
public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
    {
        var payment = new Payment
        {
            OrderId = request.OrderId,
            Amount = request.Amount,
            Method = request.Method,
            PaidAt = DateTime.UtcNow
        };

        await _repository.AddAsync(payment);

        return new PaymentResponse
        {
            Id = payment.Id,
            OrderId = payment.OrderId,
            Amount = payment.Amount,
            Method = payment.Method,
            PaidAt = payment.PaidAt
        };
    }

    public Task<PaymentResponse?> GetPaymentAsync(int id)
    {
        throw new NotImplementedException();
    }
}