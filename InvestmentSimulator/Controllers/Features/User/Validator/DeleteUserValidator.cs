using FluentValidation;
using InvestmentSimulator.Controllers.Features.User.DTOs.DeleteUser;

namespace InvestmentSimulator.Controllers.Features.User.Validator;

public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => id != Guid.Empty).WithMessage("UserId must be a valid GUID.");
    }
}
