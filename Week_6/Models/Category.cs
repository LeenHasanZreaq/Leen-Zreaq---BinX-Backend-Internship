namespace MyWebProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // علاقة مع المنتجات
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
