using Microsoft.EntityFrameworkCore;
using SnakeGameApp.Models;

namespace SnakeGameApp.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<GameRecord> GameRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<GameRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nickname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PlayTimeSeconds).IsRequired();
                entity.Property(e => e.Score).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
            });
        }
    }
}