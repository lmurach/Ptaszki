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
    }

    public DbSet<Bird> Birds { get; set; }
    // public DbSet<UserGame> UserGames { get; set; } 
}
