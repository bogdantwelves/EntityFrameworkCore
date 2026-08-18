using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

var context = new FootballLeagueDbContext();

//GetAllTeams();
//GetOneTeam();
//Select all methods that meat a condition
GetFiltredTeams();
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