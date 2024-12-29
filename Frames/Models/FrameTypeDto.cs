namespace Frames.Models;

public class FrameTypeDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? MasterRate { get; set; }
    public decimal? WorkerRate { get; set; }
}