using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class BillingSummary : EntityBase
{
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal LastMonth { get; set; }
    public long BillingId { get; set; }

    [ForeignKey(nameof(BillingId))]
    public Billing? Billing { get; set; }
}