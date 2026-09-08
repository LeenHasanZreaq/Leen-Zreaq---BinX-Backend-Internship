using Microsoft.AspNetCore.Mvc;
using MyWebProject.DTOs;
[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // POST: api/Payments
    // Create a payment
    [HttpPost]
    public async Task<IActionResult> CreatePayment(
        [FromBody] CreatePaymentRequest request)
    {
        var payment =
            await _paymentService.CreatePaymentAsync(request);

        return Ok(payment);
    }

    // GET: api/Payments
    // Get all payments
    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments =
            await _paymentService.GetAllPaymentsAsync();

        return Ok(payments);
    }

    // GET: api/Payments/5
    // Get payment by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(int id)
    {
        var payment =
            await _paymentService.GetPaymentAsync(id);

        if (payment == null)
            return NotFound(new
            {
                message = "Payment not found."
            });

        return Ok(payment);
    }

    // GET: api/Payments/order/5
    // Get payments by order
    [HttpGet("order/{orderId}")]
    public async Task<IActionResult> GetPaymentsByOrder(
        int orderId)
    {
        var payments =
            await _paymentService.GetPaymentsByOrderAsync(orderId);

        return Ok(payments);
    }

    // GET: api/Payments/customer/5
    // Get payments by customer
    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetPaymentsByCustomer(
        int customerId)
    {
        var payments =
            await _paymentService.GetPaymentsByCustomerAsync(
                customerId);

        return Ok(payments);
    }

    // PUT: api/Payments/5
    // Update payment
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(
        int id,
        [FromBody] UpdatePaymentRequest request)
    {
        var payment =
            await _paymentService.UpdatePaymentAsync(id, request);

        if (payment == null)
            return NotFound(new
            {
                message = "Payment not found."
            });

        return Ok(payment);
    }

    // DELETE: api/Payments/5
    // Delete payment
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var deleted =
            await _paymentService.DeletePaymentAsync(id);

        if (!deleted)
            return NotFound(new
            {
                message = "Payment not found."
            });

        return NoContent();
    }
}
