namespace Frames.Models;

public class FrameTypeDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public decimal? MasterRate { get; set; }
    public decimal? WorkerRate { get; set; }
}