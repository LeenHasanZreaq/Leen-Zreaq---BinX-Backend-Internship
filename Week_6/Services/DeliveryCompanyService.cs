using MyWebProject.Models;
namespace MyWebProject.Week_6.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _repository;

        public DeliveryService(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeliveryResponse> CreateDeliveryAsync(
            CreateDeliveryRequest request)
        {
            var delivery = new Delivery
            {
                OrderId = request.OrderId,
                Status = "Pending"
            };

            await _repository.AddAsync(delivery);

            return MapToResponse(delivery);
        }

        public async Task<DeliveryResponse?> AssignDriverAsync(
            int id,
            AssignDriverRequest request)
        {
            var delivery = await _repository.GetByIdAsync(id);

            if (delivery == null)
                return null;

            delivery.DriverId = request.DriverId;
            delivery.Status = "Assigned";

            await _repository.UpdateAsync(delivery);

            return MapToResponse(delivery);
        }

        public async Task<IEnumerable<DeliveryResponse>>
            GetAllDeliveriesAsync()
        {
            var deliveries = await _repository.GetAllAsync();

            return deliveries.Select(MapToResponse);
        }

        public async Task<DeliveryResponse?>
            GetDeliveryAsync(int id)
        {
            var delivery = await _repository.GetByIdAsync(id);

            if (delivery == null)
                return null;

            return MapToResponse(delivery);
        }

        public async Task<bool>
            DeleteDeliveryAsync(int id)
        {
            var delivery = await _repository.GetByIdAsync(id);

            if (delivery == null)
                return false;

            await _repository.DeleteAsync(delivery);

            return true;
        }

        private static DeliveryResponse MapToResponse(
            Delivery delivery)
        {
            return new DeliveryResponse
            {
                Id = delivery.Id,
                OrderId = delivery.OrderId,
                DriverId = delivery.DriverId,
                Status = delivery.Status
            };
        }
    }
}