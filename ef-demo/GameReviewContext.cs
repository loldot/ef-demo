using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ef_demo
{
    public class GameReviewContext : DbContext
    {
        public GameReviewContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(g => g.Etag).IsConcurrencyToken();

            modelBuilder.Entity<Game>()
                .HasData(new Game
                {
                    Id = -1,
                    Name = "Pandemic",
                    Description = "Board game where you fight multiple pandemic diseases as CDC."
                });

            

            modelBuilder.Entity<Review>()
                .HasData(new Review { Id = -1, GameId = -1, Text = "Great game!" });
        }
    }
}
