using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class Yield
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
    public int Id { get; set; }

    public UserGame User { get; set; } = default!;

    public Bird Bird { get; set; } = default!;

    [Column(TypeName="Date")]
    public DateTime Date { get; set; } = default!;

    public string BasicItemName { get; set; } = default!;

    public int Amount { get; set; }
}