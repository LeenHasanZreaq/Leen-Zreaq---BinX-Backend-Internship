namespace MyWebProject.Models
{
    public class RestaurantTable
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
