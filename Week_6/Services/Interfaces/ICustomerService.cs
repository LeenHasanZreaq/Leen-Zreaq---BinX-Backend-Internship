public interface ICustomerService
{
    Task<CustomerResponse?> GetCustomerAsync(int id);
    Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);
}
