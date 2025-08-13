namespace InvestmentSimulator.Controllers.Features.User.DTOs.GetUser;

public record GetUserRequest
{
    public Guid UserId { get; init; }
}
