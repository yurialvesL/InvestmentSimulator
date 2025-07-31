using FluentValidation;
using InvestmentSimulator.Controllers.Features.Auth.DTOs;

namespace InvestmentSimulator.Controllers.Features.Auth.Validator;

public class AuthValidator: AbstractValidator<AuthRequest>
{
    public AuthValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}
