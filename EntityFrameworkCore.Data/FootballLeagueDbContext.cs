using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFramework.Data;

public class FootballLeagueDbContext: DbContext
{
    public FootballLeagueDbContext()
    {
        var folder =  Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(path, "FootballLeague_EFCore.db");
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public string DbPath { get; private set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}")
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging() //added this only for studying
            .EnableDetailedErrors();
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