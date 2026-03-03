using System.ComponentModel.DataAnnotations;

namespace Frames.Entities;

public class FrameType : EntityBase
{
    [MaxLength(50)]
    public string Name { get; set; } = "";
    public decimal MasterFrameRate { get; set; }
    public decimal WorkerFrameRate { get; set; }
}