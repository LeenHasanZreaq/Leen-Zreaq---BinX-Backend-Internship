// DriverResponse.cs
public class DriverResponse
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int DeliveryCompanyId { get; set; }
}
