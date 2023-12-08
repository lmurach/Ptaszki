using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class UserCraftItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
    public int Id { get; set; }

    public string UserGameId { get; set; } = default!;
    public UserGame UserGame { get; set; } = default!;

    public int CraftableItemId { get; set; }
    public CraftableItem CraftableItem { get; set; } = default!;
}