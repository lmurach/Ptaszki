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


        builder.Entity<UserIR>()
            .HasKey(ir => new { ir.UserGameId, ir.BasicItemId });  
        builder.Entity<UserIR>()
            .HasOne(ir => ir.BasicItem)
            .WithMany(bi => bi.userIRs)
            .HasForeignKey(ir => ir.BasicItemId);  
        builder.Entity<UserIR>()
            .HasOne(ir => ir.UserGame)
            .WithMany(ug => ug.userIRs)
            .HasForeignKey(ir => ir.UserGameId);

        builder.Entity<UserCraftItem>()
            .HasKey(uc => new { uc.UserGameId, uc.CraftableItemId });  
        builder.Entity<UserCraftItem>()
            .HasOne(uc => uc.CraftableItem)
            .WithMany(ci => ci.userCraftItems)
            .HasForeignKey(uc => uc.CraftableItemId);  
        builder.Entity<UserCraftItem>()
            .HasOne(uc => uc.UserGame)
            .WithMany(ug => ug.userCraftItems)
            .HasForeignKey(uc => uc.UserGameId);
    }

    public DbSet<Bird> Birds { get; set; }
    public DbSet<BirdConnector> BirdConnectors { get; set; } 
    public DbSet<UserGame> UserGames { get; set; } 
    public DbSet<RolledSSB> RolledSSBs { get; set; }
    public DbSet<SideShopBird> SideShopBirds { get; set; }
    public DbSet<BasicItem> BasicItems { get; set; } 
    public DbSet<CraftableItem> CraftableItems { get; set; }
    public DbSet<JobBird> jobBirds { get; set; }
    public DbSet<Yield> Yields { get; set; }
    // public DbSet<UserIR> UserIRs { get; set; }
    // public DbSet<ItemRelationship> ItemRelationships { get; set; }
}
