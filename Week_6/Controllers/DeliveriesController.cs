```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DeliveriesController : ControllerBase
{
    private readonly IDeliveryService _deliveryService;

    public DeliveriesController(IDeliveryService deliveryService)
    {
        _deliveryService = deliveryService;
    }

    // POST: api/Deliveries
    [HttpPost]
    public async Task<IActionResult> CreateDelivery(
        [FromBody] CreateDeliveryRequest request)
    {
        return Ok(
            await _deliveryService.CreateDeliveryAsync(request)
        );
    }

    // PUT: api/Deliveries/1/assign-driver
    [HttpPut("{id}/assign-driver")]
    public async Task<IActionResult> AssignDriver(
        int id,
        [FromBody] AssignDriverRequest request)
    {
        var delivery =
            await _deliveryService.AssignDriverAsync(id, request);

        if (delivery == null)
        {
            return NotFound(new
            {
                message = "Delivery not found."
            });
        }

        return Ok(delivery);
    }

    // GET: api/Deliveries
    [HttpGet]
    public async Task<IActionResult> GetAllDeliveries()
    {
        var deliveries =
            await _deliveryService.GetAllDeliveriesAsync();

        return Ok(deliveries);
    }

    // GET: api/Deliveries/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDelivery(int id)
    {
        var delivery =
            await _deliveryService.GetDeliveryAsync(id);

        if (delivery == null)
        {
            return NotFound(new
            {
                message = "Delivery not found."
            });
        }

        return Ok(delivery);
    }

    // DELETE: api/Deliveries/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDelivery(int id)
    {
        var deleted =
            await _deliveryService.DeleteDeliveryAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Delivery not found."
            });
        }

        return NoContent();
    }
}