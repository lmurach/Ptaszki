using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class ItemRelationship
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
    public int Id { get; set; }

    public int CraftableItemId { get; set; }
    public CraftableItem CraftableItem { get; set; } = default!;

    public int BasicItemId { get; set; }
    public BasicItem BasicItem { get; set; } = default!;

    [Required]
    public int RequiredNum { get; set; }
}