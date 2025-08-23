using FluentValidation;
using InvestmentSimulator.Controllers.Features.User.DTOs.GetUser;

namespace InvestmentSimulator.Controllers.Features.User.Validator;

public class GetUserValidator : AbstractValidator<GetUserRequest>   
{
    public GetUserValidator()   
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(id => id != Guid.Empty).WithMessage("UserId must be a valid GUID.");
    }
}


