using System.ComponentModel.DataAnnotations;

namespace Frames.Entities;

public class EntityBase
{
    [Key] public int Id { get; set; }

    [Required] public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required] public DateTime ModifiedDate { get; set; } = DateTime.Now;
}