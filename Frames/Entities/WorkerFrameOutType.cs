using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class WorkerFrameOutType : EntityBase
{
    public int FrameCount { get; set; }
    public int FrameTypeId { get; set; }
    public decimal FrameRate { get; set; }
    public int FrameOutId { get; set; }
    [ForeignKey(nameof(FrameTypeId))] public FrameType? FrameType { get; set; }
    [ForeignKey(nameof(FrameOutId))] public WorkerFrameOut? WorkerFrameOut { get; set; }
}