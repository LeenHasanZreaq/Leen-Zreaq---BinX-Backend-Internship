namespace MyWebProject.DTOs;

public class UpdatePaymentRequest
{
    public UpdatePaymentRequest()
    {
    }

    public decimal Amount { get; set; }

    public string Method { get; set; } = string.Empty;
}
