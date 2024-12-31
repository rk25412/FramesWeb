namespace Frames.Models;

public class FrameOutDto
{
    public DateOnly Date { get; set; }
    public List<FrameOutTimeDto> FrameOutTimeDtos { get; set; } = [];
    public int TotalCount => FrameOutTimeDtos.Sum(x => x.TotalCount);
    public int ItemsCount => FrameOutTimeDtos.Count;
}

public class FrameOutTimeDto
{
    public int Id { get; set; }
    public TimeOnly Time { get; set; }
    public List<FrameOutTypeDto> FrameOutTypes { get; set; } = [];
    public int TotalCount => FrameOutTypes.Sum(x => x.Count);
    public int ItemsCount => FrameOutTypes.Count;
}

public class FrameOutTypeDto
{
    public int Id { get; set; }
    public int FrameTypeId { get; set; }
    public string? FrameName { get; set; }
    public int Count { get; set; }
    public decimal FrameRate { get; set; }
}