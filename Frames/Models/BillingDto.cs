namespace Frames.Models;

public class BillingDto
{
    public int Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal LastMonth { get; set; }
    public List<BillingItemDto> BillingItems { get; set; } = [];
    public List<BillingPaidDto> Paid { get; set; } = [];
}

public record BillingPaidDto(DateOnly Date, decimal Amount);
public record BillingItemDto(string Name, decimal Rate, List<BillingItemDetailDto> BillingItems);
public record BillingItemDetailDto(DateOnly Date, int Count);