using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class BirdConnector
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
    public int Id { get; set; }
    // public int UserGameId { get; set; }
    // public int BirdId { get; set; }

    public UserGame User { get; set; } = default!;

    public Bird Bird { get; set; } = default!;
}