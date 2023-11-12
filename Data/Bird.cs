using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class Bird
{
    public int ID { get; set; }
    [Key]

    public string Name { get; set; } = default!;
    [Required]
    [MaxLength(100)]

    public int Rarity { get; set; }

    public string Description { get; set; } = default!;
    [Required]
    [MaxLength(500)]

    public int Strength { get; set; }
    public int Perception { get; set; }
    public int Hunting { get; set; }
}