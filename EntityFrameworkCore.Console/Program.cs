using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

var context = new FootballLeagueDbContext();

//GetAllTeams();
//await GetAllTeamsQuerySyntax();
//GetOneTeam();
//Select all methods that meat a condition
//GetFiltredTeams();
//AggregateMethods();
//GroupByMethod();
//OrderByMethod();

async Task OrderByMethod()
{
    var orderedTeams = await context.Teams
        .OrderBy(team => team.Name)
        .ToListAsync();
    foreach (var team in orderedTeams)
    {
        Console.WriteLine(team.Name);
    }

    var orderedTeamsDescending = await context.Teams
        .OrderByDescending(team => team.Name)
        .ToListAsync();
    foreach (var team in orderedTeamsDescending)
    {
        Console.WriteLine(team.Name);
    }

    var maxBy = context.Teams.MaxBy(team => team.TeamId);
    var minBy = context.Teams.MinBy(team => team.TeamId);
}
void GroupByMethod()
{
    var groupedTeams = context.Teams
        .GroupBy(q => q.CreatedAt.Date);

    foreach (var group in groupedTeams)
    {
        Console.WriteLine(group.Key);
        Console.WriteLine(group.Sum(q => q.TeamId));

        foreach (var team in group)
        {
            Console.WriteLine(team.Name);
        }
    }
}
async Task AggregateMethods()
{
    var numberOfTeams = context.Teams.CountAsync();
    var numberOfTeamsWithCondition = context.Teams.CountAsync(q => q.TeamId == 1);
    Console.WriteLine(numberOfTeamsWithCondition.Result);

    
    var maxId = await context.Teams.MaxAsync(q => q.TeamId);
    Console.WriteLine(maxId);
    var minId = await context.Teams.MinAsync(q => q.TeamId);
    Console.WriteLine(minId);
    var avgTeams = await context.Teams.AverageAsync(q => q.TeamId);
    Console.WriteLine(avgTeams);
    var sumTeams = await context.Teams.SumAsync(q => q.TeamId);
    Console.WriteLine(sumTeams);
}
async Task GetAllTeamsQuerySyntax()
{
    Console.WriteLine("Write ur team");
    var searchTerm = Console.ReadLine();
    
    var teams = await (from team in context.Teams where
        EF.Functions.Like(team.Name, $"%{searchTerm}%")
        select team).ToListAsync();
    
    foreach (var team in teams)
    {
        Console.WriteLine(team.Name);
    }
}
async Task GetFiltredTeams()
{
    Console.WriteLine("Write ur team");
    var searchTerm = Console.ReadLine();
    var teamsFiltred = await context.Teams.Where(q => q.Name == searchTerm).ToListAsync();

    foreach (var team in teamsFiltred)
    {
        Console.WriteLine(team.TeamId);
    }
    
    // var partialMatches = await context.Teams.Where(q => q.Name.Contains(searchTerm)).ToListAsync();
    var partialMatches = await context.Teams.Where(q => EF.Functions.Like(q.Name, $"%{searchTerm}%")).ToListAsync();
    foreach (var team in partialMatches)
    {
        Console.WriteLine(team.Name);
    }
}
async void GetAllTeams()
{
    var teams = await context.Teams.ToListAsync();
    
    foreach (var t in teams)
    {
        Console.WriteLine(t.Name);
    }
}
async void GetOneTeam()
{
    //Selecting a single record - first team
    var teamOne = await context.Teams.FirstAsync();
    //Selecting a single record - first one that meet a condition
    var teamTwo = await context.Teams.FirstAsync(team => team.TeamId == 1);
    //Selecting based on ID
    var teamBaseOnId = await context.Teams.FindAsync(2);
    Console.WriteLine(teamBaseOnId.Name);
}