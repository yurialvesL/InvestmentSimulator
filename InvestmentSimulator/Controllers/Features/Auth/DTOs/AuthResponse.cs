namespace InvestmentSimulator.Controllers.Features.Auth.DTOs;

public record AuthResponse
{
    public string UserId { get; set; }
    public string Token { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public DateTime ExpiresAt { get; init; }
    public DateTime RefreshTokenExpiresAt { get; init; }
}
