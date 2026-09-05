using MyWebProject.Models;
using MyWebProject.DTOs;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    // ========================================
    // Get Customer By ID
    // ========================================

    public async Task<CustomerResponse?> GetCustomerAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            return null;

        return new CustomerResponse
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Phone = customer.Phone,
            Address = customer.Address
        };
    }

    // ========================================
    // Get All Customers
    // ========================================

    public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
    {
        var customers = await _repository.GetAllAsync();

        return customers.Select(customer => new CustomerResponse
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Phone = customer.Phone,
            Address = customer.Address
        });
    }

    // ========================================
    // Create Customer
    // ========================================

    public async Task<CustomerResponse> CreateCustomerAsync(
        CreateCustomerRequest request)
    {
        var customer = new Customer
        {
            FullName = request.FullName,
            Phone = request.Phone,
            Address = request.Address
        };

        await _repository.AddAsync(customer);

        return new CustomerResponse
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Phone = customer.Phone,
            Address = customer.Address
        };
    }

    // ========================================
    // Update Customer
    // ========================================

    public async Task<CustomerResponse?> UpdateCustomerAsync(
        int id,
        UpdateCustomerRequest request)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            return null;

        customer.FullName = request.FullName;
        customer.Phone = request.Phone;
        customer.Address = request.Address;

        await _repository.UpdateAsync(customer);

        return new CustomerResponse
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Phone = customer.Phone,
            Address = customer.Address
        };
    }

    // ========================================
    // Delete Customer
    // ========================================

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            return false;

        await _repository.DeleteAsync(customer);

        return true;
    }
}