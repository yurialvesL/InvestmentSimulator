using InvestmentSimulator.CrossCutting.Common.Interfaces;
using InvestmentSimulator.Domain.Entities;
using InvestmentSimulator.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InvestmentSimulator.Application.Commands.Users.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogger<CreateUserHandler> _logger;
    public CreateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ILogger<CreateUserHandler> logger)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _logger = logger;
    }
    public async Task<CreateUserResult?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = _passwordHasher.HashPassword(request.Password),
                DateOfBirth = request.DateOfBirth
            };

            await _userRepository.CreateUserAsync(user, cancellationToken);

            return new CreateUserResult
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };
        }
        catch (Exception ex)
        {

            _logger.LogError($"An error occured in  CreateUserHandler, Exception: {ex.Message}");
        }

        return null;
    }
}