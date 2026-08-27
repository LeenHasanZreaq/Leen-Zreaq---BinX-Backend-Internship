namespace MyWebProject.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public decimal Amount { get; set; }
        public string Method { get; set; } = "Cash"; // Cash, Card, Online

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
