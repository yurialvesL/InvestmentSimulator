using InvestmentSimulator.Application.Commands.Auth;
using InvestmentSimulator.Controllers.Features.Auth.DTOs;
using InvestmentSimulator.Controllers.Features.Auth.Validator;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.RateLimiting;

namespace InvestmentSimulator.Controllers.Features.Auth;

[EnableRateLimiting("fixed-1m")]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiConventionType(typeof(DefaultApiConventions))]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(IMediator mediator, IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;  
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Login([FromBody] AuthRequest request, CancellationToken cancellationToken)
    {
        var validator = new AuthValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<AuthenticateUserCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return response is not null 
            ? Ok(response) 
            : NotFound("User not found or invalid credentials.");
    }
}
