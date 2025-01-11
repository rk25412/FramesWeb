namespace Frames.Models;

public class BillingSummaryDto
{
    public int Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal LastMonth { get; set; }
    public decimal GrandTotal => LastMonth - TotalPaid + Total;
    public Dictionary<string, (decimal, int)> Items { get; set; } = [];
}