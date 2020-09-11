using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence
{
    public class MatchContext : DbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var matchBuilder = modelBuilder.Entity<Match>();
            matchBuilder
                .Property(e => e.MatchStatus)
                .HasConversion(new EnumToStringConverter<MatchStatus>());

            var gamePlayerBuilder = modelBuilder.Entity<GamePlayer>();
            gamePlayerBuilder
                .HasOne(gp => gp.Game)
                .WithMany(g => g.QueuedPlayers)
                .HasForeignKey(gp => gp.GameId);

            gamePlayerBuilder
                .HasOne(gp => gp.Player)
               .WithMany(p => p.InQueueForGames)
               .HasForeignKey(gp => gp.PlayerId);

            gamePlayerBuilder
                .HasKey(c => new { c.GameId, c.PlayerId });

            var matchPlayerBuilder = modelBuilder.Entity<MatchPlayer>();
            matchPlayerBuilder
                .HasOne(mp => mp.Match)
                .WithMany(g => g.Players)
                .HasForeignKey(mp => mp.MatchId);

            matchPlayerBuilder
                .HasOne(mp => mp.Player)
               .WithMany(p => p.InMatches)
               .HasForeignKey(mp => mp.PlayerId);

            matchPlayerBuilder
                .HasKey(c => new { c.MatchId, c.PlayerId });

            var gameBuilder = modelBuilder.Entity<Game>();
            gameBuilder
                .HasMany(g => g.Matches)
                .WithOne(m => m.Game)
                .HasForeignKey(mp => mp.GameId);
        }
    }
}
