namespace Frames.Entities;

public class Payments : EntityBase
{
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
}