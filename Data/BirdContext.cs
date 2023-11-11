using Microsoft.EntityFrameworkCore;
using Ptaszki.Models;

namespace ContosoUniversity.Data
{
    public class BirdContext : DbContext
    {
        public BirdContext (DbContextOptions<BirdContext> options)
            : base(options)
        {
        }

        public DbSet<Bird> Birds { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bird>().ToTable("Bird");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}