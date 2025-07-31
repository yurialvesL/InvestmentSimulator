namespace InvestmentSimulator.Application.Commands.Auth;

public class AuthenticateUserResult
{
    public Guid UserId { get; set; }
    public string Token { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public DateTime ExpiresAt { get; init; }
    public DateTime RefreshTokenExpiresAt { get; init; }

}
