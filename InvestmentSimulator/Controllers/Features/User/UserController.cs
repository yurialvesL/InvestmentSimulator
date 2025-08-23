using AutoMapper;
using InvestmentSimulator.Application.Commands.Users.CreateUser;
using InvestmentSimulator.Application.Commands.Users.DeleteUser;
using InvestmentSimulator.Application.Commands.Users.GetAllUsers;
using InvestmentSimulator.Application.Commands.Users.GetUser;
using InvestmentSimulator.Controllers.Features.User.DTOs.CreateUser;
using InvestmentSimulator.Controllers.Features.User.DTOs.DeleteUser;
using InvestmentSimulator.Controllers.Features.User.DTOs.GetAllUsers;
using InvestmentSimulator.Controllers.Features.User.DTOs.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Swashbuckle.AspNetCore.Annotations;

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


    /// <summary>
    /// Creates a new user based on the provided request data.
    /// </summary>
    /// <remarks>This method maps the incoming request to a command, processes it, and returns the appropriate
    /// HTTP response. Ensure that the <paramref name="request"/> parameter is properly populated before calling this
    /// method.</remarks>
    /// <param name="request">The request object containing the details of the user to be created. Cannot be <see langword="null"/>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation: <list type="bullet">
    /// <item><description><see cref="StatusCodes.Status201Created"/> if the user is successfully
    /// created.</description></item> <item><description><see cref="StatusCodes.Status400BadRequest"/> if the request is
    /// invalid or the user creation fails.</description></item> <item><description><see
    /// cref="StatusCodes.Status409Conflict"/> if a conflict occurs during user creation.</description></item> </list></returns>
    [HttpPost("CreateUser")]
    [SwaggerOperation(Summary = "Create an user", OperationId = "CreateUser", Description ="Create an user to simulate investment")]
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

    /// <summary>
    /// Gets a user by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetUser/{id}")]
    [Authorize]
    [SwaggerOperation(Summary = "Get an user by Id", OperationId = "GetUserById", Description = "Get an user by Id to simulate investment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetUser([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var validator = new Validator.GetUserValidator();

        var result = await validator.ValidateAsync(new GetUserRequest { UserId = id }, cancellationToken);

        if (!result.IsValid)
            return BadRequest(result.Errors);

        var command = _mapper.Map<GetUserCommand>(new GetUserRequest { UserId = id });

        var user = await _mediator.Send(command, cancellationToken);

        if (user is null)
            return NotFound("User not found.");

        var response = _mapper.Map<GetUserResponse>(user);

        return Ok(response);
    }

    /// <summary>
    /// Gets all users.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetAllUsers")]
    [Authorize]
    [SwaggerOperation(Summary = "Get all users", OperationId = "GetAllUsers", Description = "Get all users to simulate investment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var command = new GetAllUsersCommand();

        var users = await _mediator.Send(command, cancellationToken);

        if (users is null)
            return NotFound("No users found.");

        var response = _mapper.Map<GetAllUsersResponse>(users);

        return Ok(response);
    }

    /// <summary>
    /// Deletes a user by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("DeleteById/{id}")]
    [Authorize]
    [SwaggerOperation(Summary = "Delete an user by Id", OperationId = "DeleteUserById", Description = "Delete users")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var validator = new Validator.DeleteUserValidator();

        var result = await validator.ValidateAsync(new DeleteUserRequest { UserId = id }, cancellationToken);

        if (!result.IsValid)
            return BadRequest(result.Errors);

        var command = _mapper.Map<DeleteUserCommand>(new DeleteUserRequest { UserId = id });

        var isDeleted = await _mediator.Send(command, cancellationToken);

        if (isDeleted is null)
            return NotFound("User not found.");

        return NoContent();
    }
}
