// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.AspNetCore.Identity;
// namespace BirdGame.Data;

// public class UserGame
// {
//     public int ID { get; set; }
//     [Key]

//     public int Seeds { get; set; } = default!;

//     public ICollection<Bird> SideShop { get; set; } = new List<Bird>();
//     public List<int> SideShopStats { get; set; } = new List<int>();

//     public ICollection<Bird> OwnedBirds { get; set; } = new List<Bird>();
// }