public interface INotificationService
{
    Task<IEnumerable<NotificationResponse>> GetNotificationsAsync();
    Task<NotificationResponse> MarkNotificationReadAsync(int id, MarkNotificationReadRequest request);
}
