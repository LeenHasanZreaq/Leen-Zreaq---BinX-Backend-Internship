namespace MyWebProject.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Status { get; set; } = "Available"; // Available, Busy

        public int DeliveryCompanyId { get; set; }
        public DeliveryCompany DeliveryCompany { get; set; } = null!;

        public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }
}
