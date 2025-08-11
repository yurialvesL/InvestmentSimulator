
using InvestmentSimulator.Application.Commands.Users.CreateUser;
using MediatR;

namespace InvestmentSimulator.Application.Commands.Users.DeleteUser;

public class DeleteUserCommand : IRequest<DeleteUserResult>
{
    public Guid UserId { get; set; }
}
