using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
namespace EntityFramework.Data;

public class FootballLeagueDbContext: DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Coach> Coaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FootballLeague_EFCore.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasData(
            new Team
            {
                TeamId = 1,
                Name = "Manchester United",
                CreatedAt = DateTimeOffset.UtcNow.DateTime
            },
            new Team
            {
                TeamId = 2,
                Name = "Liverpool",
                CreatedAt = DateTimeOffset.UtcNow.DateTime
            },
            new Team
            {
                TeamId = 3,
                Name = "Arsenal",
                CreatedAt = DateTimeOffset.UtcNow.DateTime
            }
        );
    }
}