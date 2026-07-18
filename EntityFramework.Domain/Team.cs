namespace EntityFramework.Domain;

public class Team: BaseDomainModel
{
    public int TeamId { get; set; }
    public string? Name { get; set; }
}