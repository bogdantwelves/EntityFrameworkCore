using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

var context = new FootballLeagueDbContext();

//GetAllTeams();
//Selecting a single record - first team
var teamOne = await context.Teams.FirstAsync();
//Selecting a single record - first one that meet a condition
var teamTwo = await context.Teams.FirstAsync(team => team.TeamId == 1);
//Selecting based on ID
var teamBaseOnId = await context.Teams.FindAsync(2);
Console.WriteLine(teamBaseOnId.Name);
void GetAllTeams()
{
    var teams = context.Teams.ToList();
    
    foreach (var t in teams)
    {
        Console.WriteLine(t.Name);
    }
}
