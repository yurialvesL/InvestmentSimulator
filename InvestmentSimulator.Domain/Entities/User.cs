using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.Domain.Entities;

public class User : BaseEntitie, IUser
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public ICollection<Investment> Investments { get; set; } = new List<Investment>();
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiresAt { get; set; }
    string IUser.Id => Id.ToString(); 
    string IUser.Name => Name;
}
