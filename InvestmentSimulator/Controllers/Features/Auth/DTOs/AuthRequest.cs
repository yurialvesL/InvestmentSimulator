namespace InvestmentSimulator.Controllers.Features.Auth.DTOs;

public record AuthRequest
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
