
public interface IDeliveryService
{
    Task<DeliveryResponse> CreateDeliveryAsync(
        CreateDeliveryRequest request);

    Task<DeliveryResponse?> AssignDriverAsync(
        int id,
        AssignDriverRequest request);

    Task<IEnumerable<DeliveryResponse>> GetAllDeliveriesAsync();

    Task<DeliveryResponse?> GetDeliveryAsync(int id);

    Task<bool> DeleteDeliveryAsync(int id);
}
