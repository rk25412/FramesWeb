using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class WorkerFrameOutType : EntityBase
{
    public int FrameCount { get; set; }
    public long FrameTypeId { get; set; }
    public decimal FrameRate { get; set; }
    public long FrameOutId { get; set; }
    [ForeignKey(nameof(FrameTypeId))] public FrameType? FrameType { get; set; }
    [ForeignKey(nameof(FrameOutId))] public WorkerFrameOut? WorkerFrameOut { get; set; }
}