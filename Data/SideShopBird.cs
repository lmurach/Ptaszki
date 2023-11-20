using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirdGame.Data;

public class SideShopBird
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
    public int Id { get; set; }

    public int SlotNum { get; set; }
    
    public int Star { get; set; } = 1;

    [Required]
    public UserGame User { get; set; } = default!;

    [Required]
    public Bird Bird { get; set; } = default!;
}