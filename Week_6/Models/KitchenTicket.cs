namespace MyWebProject.Models
{
    public class KitchenTicket
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public string Status { get; set; } = "Pending"; // Pending, Cooking, Ready
    }
}
