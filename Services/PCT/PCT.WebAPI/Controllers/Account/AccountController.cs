using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCT.Application.Account.GetAll;
using PCT.Application.Account.Register;
using PCT.WebAPI.Controllers.Common;

namespace PCT.WebAPI.Controllers.Account;

public class AccountController : BaseApiController
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResponse>> Register(RegisterUserRequest userRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(userRequest, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("getAll")]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
        return Ok(response);
    }
}