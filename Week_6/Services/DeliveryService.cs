using MyWebProject.Models;
using MyWebProject.Week_6.Repositories;

public class DeliveryService : IDeliveryService
{
    private readonly MyWebProject.Week_6.Repositories.IDeliveryRepository _repository;

    public DeliveryService(
        MyWebProject.Week_6.Repositories.IDeliveryRepository repository)
    {
        _repository = repository;
    }

    // POST: Create Delivery
    public async Task<DeliveryResponse> CreateDeliveryAsync(
        CreateDeliveryRequest request)
    {
        var delivery = new Delivery
        {
            OrderId = request.OrderId,
            Status = "Pending"
        };

        await _repository.AddAsync(delivery);

        return new DeliveryResponse
        {
            Id = delivery.Id,
            OrderId = delivery.OrderId,
            DriverId = delivery.DriverId,
            Status = delivery.Status
        };
    }

    // PUT: Assign Driver
    public async Task<DeliveryResponse?> AssignDriverAsync(
        int id,
        AssignDriverRequest request)
    {
        var delivery = await _repository.GetByIdAsync(id);

        if (delivery == null)
        {
            return null;
        }

        delivery.DriverId = request.DriverId;
        delivery.Status = "Assigned";

        await _repository.UpdateAsync(delivery);

        return new DeliveryResponse
        {
            Id = delivery.Id,
            OrderId = delivery.OrderId,
            DriverId = delivery.DriverId,
            Status = delivery.Status
        };
    }

    // GET: All Deliveries
    public async Task<IEnumerable<DeliveryResponse>>
        GetAllDeliveriesAsync()
    {
        var deliveries = await _repository.GetAllAsync();

        return deliveries.Select(delivery => new DeliveryResponse
        {
            Id = delivery.Id,
            OrderId = delivery.OrderId,
            DriverId = delivery.DriverId,
            Status = delivery.Status
        });
    }

    // GET: Delivery By ID
    public async Task<DeliveryResponse?>
        GetDeliveryAsync(int id)
    {
        var delivery = await _repository.GetByIdAsync(id);

        if (delivery == null)
        {
            return null;
        }

        return new DeliveryResponse
        {
            Id = delivery.Id,
            OrderId = delivery.OrderId,
            DriverId = delivery.DriverId,
            Status = delivery.Status
        };
    }

    // DELETE: Delivery
    public async Task<bool>
        DeleteDeliveryAsync(int id)
    {
        var delivery = await _repository.GetByIdAsync(id);

        if (delivery == null)
        {
            return false;
        }

        await _repository.DeleteAsync(delivery);

        return true;
    }
}
