using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace BirdGame.Data;

public class UserGame
{
    [Key]
    [Column(TypeName = "text")]
    public string Id { get; set; } = default!;

    public int Seeds { get; set; } = default!;

    public ICollection<BirdConnector> OwnedBirds { get; set; } = new List<BirdConnector>();
}