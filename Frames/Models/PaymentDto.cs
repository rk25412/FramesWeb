namespace Frames.Models;

public class PaymentDto
{
    public long Id { get; set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
}