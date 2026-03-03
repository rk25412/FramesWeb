namespace Frames.Entities;

public class Payment : EntityBase
{
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
}