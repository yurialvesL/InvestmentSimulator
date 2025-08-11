using InvestmentSimulator.Domain.Entities;

namespace InvestmentSimulator.Application.Commands.Users.GetAllUsers;

public class GetAllUsersResult
{
    public List<User>? Users { get; set; }
}
