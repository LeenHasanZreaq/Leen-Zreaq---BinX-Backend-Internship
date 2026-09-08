using MyWebProject.DTOs;
public interface IPaymentService
{
    Task<PaymentResponse> CreatePaymentAsync(
        CreatePaymentRequest request);

    Task<PaymentResponse?> GetPaymentAsync(int id);

    Task<IEnumerable<PaymentResponse>> GetAllPaymentsAsync();

    Task<IEnumerable<PaymentResponse>> GetPaymentsByOrderAsync(
        int orderId);

    Task<IEnumerable<PaymentResponse>> GetPaymentsByCustomerAsync(
        int customerId);

    Task<PaymentResponse?> UpdatePaymentAsync(
        int id,
        UpdatePaymentRequest request);

    Task<bool> DeletePaymentAsync(int id);
}
