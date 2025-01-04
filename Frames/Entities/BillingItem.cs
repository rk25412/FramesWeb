using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class BillingItem : EntityBase
{
    public string? ItemName { get; set; }
    public decimal Rate { get; set; }
    public int BillingId { get; set; }

    [ForeignKey(nameof(BillingId))]
    public Billing? Billing { get; set; }

    public List<BillingItemDetail> BillingItemDetails { get; set; } = [];
}