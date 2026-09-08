using MyWebProject.DTOs;

public interface IKitchenService
{
    Task<IEnumerable<KitchenTicketResponse>> GetKitchenTicketsAsync();

    Task<KitchenTicketResponse?> GetKitchenTicketByIdAsync(int id);

    Task<IEnumerable<KitchenTicketResponse>>
        GetKitchenTicketsByStatusAsync(string status);

    Task<KitchenTicketResponse?> UpdateKitchenStatusAsync(
        int id,
        UpdateKitchenStatusRequest request);

    Task<bool> DeleteKitchenTicketAsync(int id);

    Task<KitchenStatistics> GetKitchenStatisticsAsync();
}