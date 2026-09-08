using MyWebProject.Models;

namespace MyWebProject.Week_6.Repositories
{
    public interface IDeliveryRepository
    {
        Task<Delivery?> GetByIdAsync(int id);
        Task<IEnumerable<Delivery>> GetAllAsync();

        Task AddAsync(Delivery delivery);

        Task UpdateAsync(Delivery delivery);

        Task DeleteAsync(Delivery delivery);
    }
}