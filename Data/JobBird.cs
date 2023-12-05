using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class JobBird
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
    public int Id { get; set; }

    [Required]
    public UserGame User { get; set; } = default!;

    [Required]
    public Bird Bird { get; set; } = default!;

    public string jobTitle { get; set; } = "gatherer";
}