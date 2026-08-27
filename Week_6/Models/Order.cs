namespace MyWebProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // Pending, Preparing, Ready, Delivered

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int? TableId { get; set; }
        public RestaurantTable? Table { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
