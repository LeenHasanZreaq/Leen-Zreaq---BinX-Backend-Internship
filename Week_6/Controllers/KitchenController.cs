using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class KitchenController : ControllerBase
{
    private readonly IKitchenService _kitchenService;

    public KitchenController(IKitchenService kitchenService)
    {
        _kitchenService = kitchenService;
    }

    [HttpGet("tickets")]
    public async Task<IActionResult> GetTickets() =>
        Ok(await _kitchenService.GetKitchenTicketsAsync());

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateKitchenStatusRequest request) =>
        Ok(await _kitchenService.UpdateKitchenStatusAsync(id, request));
}
