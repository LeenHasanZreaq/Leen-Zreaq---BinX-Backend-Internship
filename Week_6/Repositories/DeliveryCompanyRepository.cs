
using MyWebProject.Data;
using MyWebProject.Models;
using Microsoft.EntityFrameworkCore;

public class DeliveryCompanyRepository : IDeliveryCompanyRepository
{
    private readonly PizzaRestaurantDbContext _context;

    public DeliveryCompanyRepository(PizzaRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DeliveryCompany>> GetAllAsync() =>
        await _context.DeliveryCompanies.ToListAsync();

    public async Task AddAsync(DeliveryCompany company)
    {
        _context.DeliveryCompanies.Add(company);
        await _context.SaveChangesAsync();
    }
}
