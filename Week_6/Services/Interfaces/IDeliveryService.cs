public interface IDeliveryService
{
    Task<DeliveryResponse> CreateDeliveryAsync(CreateDeliveryRequest request);
    Task<DeliveryResponse> AssignDriverAsync(int id, AssignDriverRequest request);
}
