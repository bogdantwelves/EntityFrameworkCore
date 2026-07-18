using EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
namespace EntityFramework.Data;

public class FootballLeagueDbContext: DbContext
{
    private string DbPath;
    public DbSet<Team> Teams { get; set; }
    public DbSet<Coach> Coaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FootballLeague_EFCore.db");
    }
}