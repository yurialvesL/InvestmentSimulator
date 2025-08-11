using MediatR;

namespace InvestmentSimulator.Application.Commands.Users.GetUser;

public class GetUserCommand :IRequest<GetUserResult>
{
    public Guid UserId { get; set; }
}
