namespace InvestmentSimulator.Controllers.Features.User.DTOs.DeleteUser;

public record DeleteUserRequest
{
    public Guid UserId { get; init; }
}
