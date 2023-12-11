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

    public string JobTitle { get; set; } = "gatherer";

    public int SlotNum { get; set; }

    public int JS_SeedCollector { get; set; }
    public int JS_RockBreaker { get; set; }
    public int JS_Gatherer { get; set; }
    public int JS_Hunter { get; set; }
    public int JS_FeatherFeatcher { get; set; }
    public int JS_BugFinder { get; set; }
}