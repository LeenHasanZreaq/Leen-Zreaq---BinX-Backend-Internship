using MyWebProject.Data;
using MyWebProject.Models;
using Microsoft.EntityFrameworkCore;

public class NotificationRepository : INotificationRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public NotificationRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TableNotification>> GetAllAsync() =>
        await _context.Notifications.ToListAsync();

    public async Task<TableNotification?> GetByIdAsync(int id) =>
        await _context.Notifications.FindAsync(id);

    public async Task UpdateAsync(TableNotification notification)
    {
        _context.Notifications.Update(notification);
        await _context.SaveChangesAsync();
    }
}
