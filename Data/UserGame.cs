using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace BirdGame.Data;

public class UserGame
{
    [Key]
    [Column(TypeName = "text")]
    public string Id { get; set; } = default!;

    public int Seeds { get; set; } = 100;

    public int RarityUpgrade { get; set; } = default!;

    public List<BirdConnector> OwnedBirds { get; set; } = new List<BirdConnector>();
    public List<RolledSSB> rolledSSBs { get; set; } = new List<RolledSSB>();
    public List<SideShopBird> sideShopBirds { get; set; } = new List<SideShopBird>();
    public List<UserIR> userIRs { get; set; } = new List<UserIR>();
    public List<JobBird> jobBirds { get; set; } = new List<JobBird>();
}