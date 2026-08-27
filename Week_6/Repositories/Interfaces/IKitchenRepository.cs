using MyWebProject.Models;

public interface IKitchenRepository
{
    Task<IEnumerable<KitchenTicket>> GetAllAsync();
    Task<KitchenTicket?> GetByIdAsync(int id);
    Task UpdateAsync(KitchenTicket ticket);
}
