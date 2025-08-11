using InvestmentSimulator.Application.Commands.Users.CreateUser;
using InvestmentSimulator.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentSimulator.Application.Commands.Users.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<DeleteUserHandler> _logger;


    public DeleteUserHandler(IUserRepository userRepository, ILogger<DeleteUserHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<DeleteUserResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            _logger.LogWarning($"User with ID {request.UserId} not found.");
            return new DeleteUserResult { Deleted = false};
        }

        var result = await _userRepository.DeleteUserAsync(request.UserId, cancellationToken);
        if (result)
        {
            _logger.LogInformation($"User with ID {request.UserId} deleted successfully.");
            return new DeleteUserResult { Deleted = true };
        }

        _logger.LogError($"Failed to delete user with ID {request.UserId}.");
        return new DeleteUserResult { Deleted = false };
    }
}
