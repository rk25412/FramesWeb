using System.ComponentModel.DataAnnotations;

namespace Frames.Entities;

public class Worker : EntityBase
{
    [MaxLength(50)]
    public string Name { get; set; } = "";
}