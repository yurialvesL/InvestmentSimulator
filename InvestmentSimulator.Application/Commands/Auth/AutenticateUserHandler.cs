using InvestmentSimulator.CrossCutting.Common.Interfaces;
using InvestmentSimulator.Domain.Interfaces;
using MediatR;

namespace InvestmentSimulator.Application.Commands.Auth;

public class AutenticateUserHandler: IRequestHandler<AuthenticateUserCommand,AuthenticateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;


    public AutenticateUserHandler(IUserRepository userRepository,IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
    }

    public async Task<AuthenticateUserResult> Handle(AuthenticateUserCommand auth, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(auth.Email, cancellationToken);

        if (user == null || !_passwordHasher.VerifyHashedPassword(auth.Password, user.PasswordHash))
        {
            return null; // User not found or invalid credentials
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticateUserResult
        {
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddHours(8), 
            Token = token,
            RefreshToken = "Vou implementar amanhã kk",
            RefreshTokenExpiresAt = DateTime.UtcNow.AddHours(8) // Example expiration time
        };      
    }
}
