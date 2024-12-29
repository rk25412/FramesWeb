using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class WorkerFrameIn : EntityBase
{
    public DateTime Date { get; set; }
    public int NoOfFrames { get; set; }
    public int WorkerId { get; set; }
    [ForeignKey(nameof(WorkerId))] public Worker? Worker { get; set; }
}