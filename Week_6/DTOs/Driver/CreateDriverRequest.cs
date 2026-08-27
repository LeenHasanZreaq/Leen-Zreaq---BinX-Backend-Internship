// CreateDriverRequest.cs
public class CreateDriverRequest
{
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int DeliveryCompanyId { get; set; }
}
