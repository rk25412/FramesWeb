using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class MasterFrameOutType : EntityBase
{
    public long MasterFrameOutId { get; set; }
    public long FrameTypeId { get; set; }
    public decimal FrameRate { get; set; }
    public int Count { get; set; }
    [ForeignKey(nameof(FrameTypeId))] public FrameType? FrameType { get; set; }
    [ForeignKey(nameof(MasterFrameOutId))] public MasterFrameOut? MasterFrameOut { get; set; }
}