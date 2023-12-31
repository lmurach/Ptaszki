using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class BasicItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    public string JobAssociation { get; set; } = default!;
    public int rarity { get; set; } = default!;

    public List<ItemRelationship> itemRelationships { get; set; } = default!;
    public List<UserIR> userIRs { get; set; } = default!;
}