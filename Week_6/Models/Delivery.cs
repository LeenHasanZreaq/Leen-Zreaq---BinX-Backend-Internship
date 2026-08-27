namespace MyWebProject.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // Pending, OnTheWay, Delivered

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int DriverId { get; set; }
        public Driver Driver { get; set; } = null!;
    }
}
