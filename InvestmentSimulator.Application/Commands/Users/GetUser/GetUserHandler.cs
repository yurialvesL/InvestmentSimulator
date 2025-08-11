using InvestmentSimulator.Application.Commands.Users.DeleteUser;
using InvestmentSimulator.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentSimulator.Application.Commands.Users.GetUser;

public class GetUserHandler : IRequestHandler<GetUserCommand, GetUserResult>
{

    private readonly IUserRepository _userRepository;
    private readonly ILogger<GetUserHandler> _logger;

    public GetUserHandler(IUserRepository userRepository, ILogger<GetUserHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<GetUserResult?> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {request.UserId} not found.");
                return null;
            }
            return new GetUserResult
            {
                UserResult = user
            };
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred in GetUserHandler, Exception: {ex.Message}");
            return null;
        }
    }
}
