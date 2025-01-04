using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class BillingItemDetail : EntityBase
{
    public DateOnly Date { get; set; }
    public int Count { get; set; }
    public int BillingItemId { get; set; }

    [ForeignKey(nameof(BillingItemId))]
    public BillingItem? BillingItem { get; set; }
}