namespace InvestmentSimulator.Controllers.Features.User.DTOs.CreateUser;

public record CreateUserRequest
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
}
