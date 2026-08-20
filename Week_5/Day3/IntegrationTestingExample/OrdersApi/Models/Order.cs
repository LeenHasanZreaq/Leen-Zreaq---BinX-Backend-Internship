namespace OrdersApi.Models;

public class Order
{
    public int Id { get; set; }
    public string Product { get; set; } = "";
    public decimal Total { get; set; }
}