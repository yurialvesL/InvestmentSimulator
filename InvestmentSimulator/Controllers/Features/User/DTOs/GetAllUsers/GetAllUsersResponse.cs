using InvestmentSimulator.Controllers.Features.User.DTOs.GetUser;

namespace InvestmentSimulator.Controllers.Features.User.DTOs.GetAllUsers;

public record GetAllUsersResponse
{
    public List<GetUserResponse>? Users { get; init; }
}
