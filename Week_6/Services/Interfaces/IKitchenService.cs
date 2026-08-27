public interface IKitchenService
{
    Task<IEnumerable<KitchenTicketResponse>> GetKitchenTicketsAsync();
    Task<KitchenTicketResponse> UpdateKitchenStatusAsync(int id, UpdateKitchenStatusRequest request);
}
