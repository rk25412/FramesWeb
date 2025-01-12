using System.Collections.Frozen;

namespace Frames.Models;

public class BillingDto
{
    public int Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal LastMonth { get; set; }
    public List<BillingItemDto> BillingItems { get; set; } = [];
    public List<BillingPaidDto> Paid { get; set; } = [];
    public decimal TotalPaid => Paid.Sum(x => x.Amount);
    public decimal TotalAmt => BillingItems.Sum(x => x.TotalAmt);
    public decimal LeftFromLastMonth => LastMonth - TotalPaid;
    public decimal GrandTotal => LeftFromLastMonth + TotalAmt;
}

public record BillingPaidDto(DateOnly Date, decimal Amount);

public record BillingItemDto(string Name, decimal Rate, List<BillingItemDetailDto> BillingItems)
{
    public decimal TotalCount => BillingItems.Sum(x => x.Count);
    public decimal TotalAmt => Rate * TotalCount;
    public FrozenDictionary<DateOnly, int> BillingItemDictionary =>
        BillingItems.ToFrozenDictionary(x => x.Date, x => x.Count);
}
public record BillingItemDetailDto(DateOnly Date, int Count);