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

    // GET: api/Kitchen/tickets
    [HttpGet("tickets")]
    public async Task<IActionResult> GetTickets()
    {
        var tickets = await _kitchenService.GetKitchenTicketsAsync();
        return Ok(tickets);
    }

    // GET: api/Kitchen/tickets/{id}
    [HttpGet("tickets/{id}")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var ticket = await _kitchenService.GetKitchenTicketByIdAsync(id);

        if (ticket == null)
            return NotFound(new
            {
                message = "Kitchen ticket not found."
            });

        return Ok(ticket);
    }

    // GET: api/Kitchen/tickets/status/{status}
    [HttpGet("tickets/status/{status}")]
    public async Task<IActionResult> GetTicketsByStatus(string status)
    {
        var tickets =
            await _kitchenService.GetKitchenTicketsByStatusAsync(status);

        return Ok(tickets);
    }

    // GET: api/Kitchen/tickets/pending
    [HttpGet("tickets/pending")]
    public async Task<IActionResult> GetPendingTickets()
    {
        var tickets =
            await _kitchenService.GetKitchenTicketsByStatusAsync("Pending");

        return Ok(tickets);
    }

    // GET: api/Kitchen/tickets/in-progress
    [HttpGet("tickets/in-progress")]
    public async Task<IActionResult> GetInProgressTickets()
    {
        var tickets =
            await _kitchenService.GetKitchenTicketsByStatusAsync("InProgress");

        return Ok(tickets);
    }

    // GET: api/Kitchen/tickets/completed
    [HttpGet("tickets/completed")]
    public async Task<IActionResult> GetCompletedTickets()
    {
        var tickets =
            await _kitchenService.GetKitchenTicketsByStatusAsync("Completed");

        return Ok(tickets);
    }

    // PUT: api/Kitchen/{id}/status
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] UpdateKitchenStatusRequest request)
    {
        var result =
            await _kitchenService.UpdateKitchenStatusAsync(id, request);

        if (result == null)
            return NotFound(new
            {
                message = "Kitchen ticket not found."
            });

        return Ok(result);
    }

    // DELETE: api/Kitchen/tickets/{id}
    [HttpDelete("tickets/{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var deleted =
            await _kitchenService.DeleteKitchenTicketAsync(id);

        if (!deleted)
            return NotFound(new
            {
                message = "Kitchen ticket not found."
            });

        return NoContent();
    }

    // GET: api/Kitchen/statistics
    [HttpGet("statistics")]
    public async Task<IActionResult> GetStatistics()
    {
        var statistics =
            await _kitchenService.GetKitchenStatisticsAsync();

        return Ok(statistics);
    }
}