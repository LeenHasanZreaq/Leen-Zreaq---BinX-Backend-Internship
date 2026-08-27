namespace MyWebProject.Models
{
    public class TableNotification
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public RestaurantTable Table { get; set; } = null!;
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
    }
}
