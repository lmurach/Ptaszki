using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class Bird
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;
    
    [Required]
    public int Rarity { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = default!;

    public int Strength { get; set; }
    public int Perception { get; set; }
    public int Hunting { get; set; }
}