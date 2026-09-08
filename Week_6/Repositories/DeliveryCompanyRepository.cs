using Microsoft.EntityFrameworkCore;
using MyWebProject.Data;
using MyWebProject.Models;

namespace MyWebProject.Week_6.Repositories
{
    public class DeliveryCompanyRepository : IDeliveryCompanyRepository
    {
        private readonly PizzaRestaurantDbContext _context;

        public DeliveryCompanyRepository(PizzaRestaurantDbContext context)
        {
            _context = context;
        }

        // GET COMPANY BY ID
        public async Task<DeliveryCompany?> GetByIdAsync(int id)
        {
            return await _context.DeliveryCompanies
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // GET ALL COMPANIES
        public async Task<IEnumerable<DeliveryCompany>> GetAllAsync()
        {
            return await _context.DeliveryCompanies
                .ToListAsync();
        }

        // SEARCH COMPANIES
        public async Task<IEnumerable<DeliveryCompany>> SearchAsync(string name)
        {
            return await _context.DeliveryCompanies
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }

        // CREATE COMPANY
        public async Task AddAsync(DeliveryCompany company)
        {
            _context.DeliveryCompanies.Add(company);

            await _context.SaveChangesAsync();
        }

        // UPDATE COMPANY
        public async Task UpdateAsync(DeliveryCompany company)
        {
            _context.DeliveryCompanies.Update(company);

            await _context.SaveChangesAsync();
        }

        // DELETE COMPANY
        public async Task DeleteAsync(DeliveryCompany company)
        {
            _context.DeliveryCompanies.Remove(company);

            await _context.SaveChangesAsync();
        }
    }
}
