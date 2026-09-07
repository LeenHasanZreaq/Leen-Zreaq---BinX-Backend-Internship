
public class DeliveryResponse
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int? DriverId { get; set; }

    public string Status { get; set; } = string.Empty;
}
