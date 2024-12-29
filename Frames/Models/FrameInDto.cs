namespace Frames.Models;

public class FrameInDto
{
    public DateOnly Date { get; set; }
    public List<FrameInTimeAndCount> InItems { get; set; } = [];
    public int TotalCount => InItems.Sum(x => x.Count);
    public int ItemsCount => InItems.Count;
}

public class FrameInTimeAndCount
{
    public int Id { get; set; }
    public TimeOnly Time { get; set; }
    public int Count { get; set; }
}