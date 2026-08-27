
using MyWebProject.Models;
using MyWebProject.DTOs;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse?> GetCustomerAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer == null) return null;

        return new CustomerResponse
        {
            Id = customer.Id,
            FullName = customer.FullName,
            Phone = customer.Phone,
            Address = customer.Address
        };
    }

    public async Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
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
}
