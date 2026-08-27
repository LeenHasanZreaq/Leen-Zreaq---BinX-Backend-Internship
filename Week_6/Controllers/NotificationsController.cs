using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetNotifications() =>
        Ok(await _notificationService.GetNotificationsAsync());

    [HttpPut("{id}/read")]
    public async Task<IActionResult> MarkRead(int id, [FromBody] MarkNotificationReadRequest request) =>
        Ok(await _notificationService.MarkNotificationReadAsync(id, request));
}
