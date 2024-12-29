namespace Frames.Entities;

public class MasterFrameOut : EntityBase
{
    public DateTime DateTime { get; set; }
    public List<MasterFrameOutType> MasterFrameOutTypes { get; set; } = [];
}