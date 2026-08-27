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

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request) =>
        Ok(await _customerService.CreateCustomerAsync(request));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id) =>
        Ok(await _customerService.GetCustomerAsync(id));
}
