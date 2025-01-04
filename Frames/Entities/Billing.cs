namespace Frames.Entities;

public class Billing : EntityBase
{
    public int Month { get; set; }
    public int Year { get; set; }

    public List<BillingItem> BillingItems { get; set; } = [];
    public List<Paid> Paid { get; set; } = [];
}