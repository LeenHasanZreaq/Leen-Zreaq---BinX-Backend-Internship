using MyWebProject.Models;

public interface INotificationRepository
{
    Task<IEnumerable<TableNotification>> GetAllAsync();
    Task<TableNotification?> GetByIdAsync(int id);
    Task UpdateAsync(TableNotification notification);
}
