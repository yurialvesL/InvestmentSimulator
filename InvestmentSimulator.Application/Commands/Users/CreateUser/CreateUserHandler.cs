using InvestmentSimulator.CrossCutting.Common.Interfaces;
using InvestmentSimulator.Domain.Entities;
using InvestmentSimulator.Domain.Interfaces;
using MediatR;

namespace InvestmentSimulator.Application.Commands.Users.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    public CreateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            DateOfBirth = request.DateOfBirth
        };

        await _userRepository.CreateUserAsync(user);

        return new CreateUserResult
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth
        };
    }
}