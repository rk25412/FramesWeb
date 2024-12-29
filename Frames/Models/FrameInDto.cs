namespace Frames.Models;

public class FrameInDto
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public List<FrameInTimeAndCount> InItems { get; set; } = [];
    public int ItemsCount => InItems.Count;
}

public class FrameInTimeAndCount
{
    public TimeOnly Time { get; set; }
    public int Count { get; set; }
}