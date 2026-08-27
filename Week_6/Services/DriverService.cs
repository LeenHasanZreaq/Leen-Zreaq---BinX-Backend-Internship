using MyWebProject.Models;
using MyWebProject.DTOs;
public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _repository;

    public DeliveryService(IDeliveryRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeliveryResponse> CreateDeliveryAsync(CreateDeliveryRequest request)
    {
        var delivery = new Delivery
        {
            OrderId = request.OrderId,
            DriverId = request.DriverId,
            Status = "Pending",
            AssignedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(delivery);

        return new DeliveryResponse
        {
            Id = delivery.Id,
            OrderId = delivery.OrderId,
            DriverId = delivery.DriverId,
            Status = delivery.Status,
            AssignedAt = delivery.AssignedAt
        };
    }

    public async Task<DeliveryResponse> AssignDriverAsync(int id, AssignDriverRequest request)
    {
        var delivery = await _repository.GetByIdAsync(id);
        if (delivery == null) throw new Exception("Delivery not found");

        delivery.DriverId = request.DriverId;
        delivery.Status = "OnTheWay";
        await _repository.UpdateAsync(delivery);

        return new DeliveryResponse
        {
            Id = delivery.Id,
            OrderId = delivery.OrderId,
            DriverId = delivery.DriverId,
            Status = delivery.Status,
            AssignedAt = delivery.AssignedAt
        };
    }
}
