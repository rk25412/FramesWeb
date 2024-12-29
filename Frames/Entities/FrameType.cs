namespace Frames.Entities;

public class FrameType : EntityBase
{
    public string Name { get; set; } = "";
    public decimal MasterFrameRate { get; set; }
    public decimal WorkerFrameRate { get; set; }
}