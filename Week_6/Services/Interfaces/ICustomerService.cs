public interface ICustomerService
{
    Task<CustomerResponse?> GetCustomerAsync(int id);

    Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();

    Task<CustomerResponse> CreateCustomerAsync(
        CreateCustomerRequest request);

    Task<CustomerResponse?> UpdateCustomerAsync(
        int id,
        UpdateCustomerRequest request);

    Task<bool> DeleteCustomerAsync(int id);
}