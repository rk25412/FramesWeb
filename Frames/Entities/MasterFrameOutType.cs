using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class MasterFrameOutType : EntityBase
{
    public int FrameTypeId { get; set; }
    public decimal FrameRate { get; set; }
    public int Count { get; set; }
    [ForeignKey(nameof(FrameTypeId))] public FrameType? FrameType { get; set; }
}