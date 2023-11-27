using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BirdGame.Data;

public class BirdDbContext : IdentityDbContext<IdentityUser>
{
    public BirdDbContext(DbContextOptions<BirdDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<ItemRelationship>()
            .HasKey(ir => new { ir.BasicItemId, ir.CraftableItemId });  
        builder.Entity<ItemRelationship>()
            .HasOne(ir => ir.BasicItem)
            .WithMany(bi => bi.itemRelationships)
            .HasForeignKey(ir => ir.BasicItemId);  
        builder.Entity<ItemRelationship>()
            .HasOne(ir => ir.CraftableItem)
            .WithMany(ci => ci.itemRelationships)
            .HasForeignKey(ir => ir.CraftableItemId);
    }

    public DbSet<Bird> Birds { get; set; }
    public DbSet<BirdConnector> BirdConnectors { get; set; } 
    public DbSet<UserGame> UserGames { get; set; } 
    public DbSet<RolledSSB> RolledSSBs {get; set; }
    public DbSet<SideShopBird> SideShopBirds { get; set; }
    public DbSet<BasicItem> BasicItems { get; set; } 
    public DbSet<CraftableItem> CraftableItems {get; set; }
    // public DbSet<ItemRelationship> ItemRelationships { get; set; }
}
