using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class UserIR
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
    public int Id { get; set; }

    public string UserGameId { get; set; } = default!;
    public UserGame UserGame { get; set; } = default!;

    public int BasicItemId { get; set; }
    public BasicItem BasicItem { get; set; } = default!;

    [Required]
    public int OwnedNum { get; set; }
}