namespace MyWebProject.Models
{
    public class DeliveryCompany
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    }
}
