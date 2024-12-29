using System.ComponentModel.DataAnnotations;

namespace Frames.Entities;

public class EntityBase
{
    [Key] public int Id { get; set; }
}