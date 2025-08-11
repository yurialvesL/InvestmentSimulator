using InvestmentSimulator.Domain.Entities;
using InvestmentSimulator.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentSimulator.Application.Commands.Users.GetAllUsers;

public class GetAllUsersHandler :  IRequestHandler<GetAllUsersCommand, GetAllUsersResult>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<GetAllUsersHandler> _logger;

    public GetAllUsersHandler(IUserRepository userRepository, ILogger<GetAllUsersHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<GetAllUsersResult> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving all users from the repository.");
        var users = await _userRepository.GetAllUsersAsync(cancellationToken);
        
        if (users is null || users.Count == 0)
        {
            _logger.LogWarning("No users found in the repository.");
            return new GetAllUsersResult { Users = null};
        }
        _logger.LogInformation($"Retrieved {users.Count} users from the repository.");

        return new GetAllUsersResult { Users = users };
    }
}
