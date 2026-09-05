namespace MyWebProject.DTOs
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
    }
}
