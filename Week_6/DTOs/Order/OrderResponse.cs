namespace MyWebProject.DTOs
{
    public class OrderItemResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Status { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
    }
}
