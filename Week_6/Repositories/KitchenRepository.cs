using MyWebProject.Data;
using MyWebProject.Models;
using Microsoft.EntityFrameworkCore;

public class KitchenRepository : IKitchenRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public KitchenRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<KitchenTicket>> GetAllAsync() =>
        await _context.KitchenTickets.ToListAsync();

    public async Task<KitchenTicket?> GetByIdAsync(int id) =>
        await _context.KitchenTickets.FindAsync(id);

    public async Task UpdateAsync(KitchenTicket ticket)
    {
        _context.KitchenTickets.Update(ticket);
        await _context.SaveChangesAsync();
    }
}
