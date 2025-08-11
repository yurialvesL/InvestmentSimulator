using AutoMapper;
using InvestmentSimulator.Application.Commands.Users.CreateUser;
using InvestmentSimulator.Controllers.Features.User.DTOs.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InvestmentSimulator.Controllers.Features.User;


[EnableRateLimiting("fixed-1m")]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiConventionType(typeof(DefaultApiConventions))]
public class UserController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost("CreateUser")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            return BadRequest("Request cannot be null.");

        var command = _mapper.Map<CreateUserCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        if (result is null)
            return BadRequest("Failed to create user.");

        var response = _mapper.Map<CreateUserResponse>(result);

        return Created(string.Empty,response);
    }
}
