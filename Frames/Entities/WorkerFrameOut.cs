using System.ComponentModel.DataAnnotations.Schema;

namespace Frames.Entities;

public class WorkerFrameOut : EntityBase
{
    public DateTime Date { get; set; }
    public int WorkerId { get; set; }
    [ForeignKey(nameof(WorkerId))] public Worker? Worker { get; set; }
    public List<WorkerFrameOutType> WorkerFrameOutTypes { get; set; } = [];
}