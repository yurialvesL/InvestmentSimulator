using FluentValidation;
using InvestmentSimulator.Controllers.Features.User.DTOs.CreateUser;

namespace InvestmentSimulator.Controllers.Features.User.Validator;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(256).WithMessage("Email must not exceed 256 characters.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");
        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.")
            .LessThan(DateTime.UtcNow).WithMessage("Date of Birth must be in the past.");
    }
}

