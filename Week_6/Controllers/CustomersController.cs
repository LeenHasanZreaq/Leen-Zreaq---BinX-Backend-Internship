using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // ========================================
    // POST: api/Customers
    // Create Customer
    // ========================================

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(
        [FromBody] CreateCustomerRequest request)
    {
        var customer =
            await _customerService.CreateCustomerAsync(request);

        return Ok(customer);
    }

    // ========================================
    // GET: api/Customers/{id}
    // Get Customer by ID
    // ========================================

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer =
            await _customerService.GetCustomerAsync(id);

        if (customer == null)
        {
            return NotFound(new
            {
                message = "Customer not found."
            });
        }

        return Ok(customer);
    }

    // ========================================
    // GET: api/Customers
    // Get All Customers
    // ========================================

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers =
            await _customerService.GetAllCustomersAsync();

        return Ok(customers);
    }

    // ========================================
    // PUT: api/Customers/{id}
    // Update Customer
    // ========================================

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(
        int id,
        [FromBody] UpdateCustomerRequest request)
    {
        var customer =
            await _customerService.UpdateCustomerAsync(id, request);

        if (customer == null)
        {
            return NotFound(new
            {
                message = "Customer not found."
            });
        }

        return Ok(customer);
    }

    // ========================================
    // DELETE: api/Customers/{id}
    // Delete Customer
    // ========================================

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var deleted =
            await _customerService.DeleteCustomerAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Customer not found."
            });
        }

        return NoContent();
    }
}