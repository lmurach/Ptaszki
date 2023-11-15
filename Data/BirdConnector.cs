using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class BirdConnector
{
    public int Id { get; set; }
    public int UserGameId { get; set; }
    public int BirdId { get; set; }

    public UserGame User { get; set; } = default!;

    public Bird Bird { get; set; } = default!;
}