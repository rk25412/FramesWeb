using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class BillingItem : EntityBase
{
    [MaxLength(50)]
    public string? ItemName { get; set; }
    public decimal Rate { get; set; }
    public long BillingId { get; set; }

    [ForeignKey(nameof(BillingId))]
    public Billing? Billing { get; set; }

    public List<BillingItemDetail> BillingItemDetails { get; set; } = [];
}