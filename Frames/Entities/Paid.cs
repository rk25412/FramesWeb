using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class Paid : EntityBase
{
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
    public long PaymentId { get; set; }
    public long BillingId { get; set; }

    [ForeignKey(nameof(BillingId))]
    public Billing? Billing { get; set; }
}