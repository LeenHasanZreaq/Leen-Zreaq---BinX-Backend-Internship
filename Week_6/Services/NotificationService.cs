public class NotificationService : INotificationService
{
    private readonly INotificationRepository _repository;

    public NotificationService(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<NotificationResponse>> GetNotificationsAsync()
    {
        var notifications = await _repository.GetAllAsync();
        return notifications.Select(n => new NotificationResponse
        {
            Id = n.Id,
            TableId = n.TableId,
            Message = n.Message,
            IsRead = n.IsRead
        });
    }

    public async Task<NotificationResponse> MarkNotificationReadAsync(int id, MarkNotificationReadRequest request)
    {
        var notification = await _repository.GetByIdAsync(id);
        if (notification == null) throw new Exception("Notification not found");

        notification.IsRead = request.IsRead;
        await _repository.UpdateAsync(notification);

        return new NotificationResponse
        {
            Id = notification.Id,
            TableId = notification.TableId,
            Message = notification.Message,
            IsRead = notification.IsRead
        };
    }
}
