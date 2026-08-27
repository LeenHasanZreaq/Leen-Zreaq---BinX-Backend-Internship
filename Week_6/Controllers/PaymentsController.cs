using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request) =>
        Ok(await _paymentService.CreatePaymentAsync(request));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(int id) =>
        Ok(await _paymentService.GetPaymentAsync(id));
}
