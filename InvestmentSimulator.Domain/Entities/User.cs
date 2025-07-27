namespace InvestmentSimulator.Domain.Entities;

public class User : BaseEntitie
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public ICollection<Investment> Investments { get; set; } = new List<Investment>();
}
