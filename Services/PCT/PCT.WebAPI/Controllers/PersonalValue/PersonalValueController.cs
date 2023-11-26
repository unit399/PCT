using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCT.Domain.PersonalValue.Dtos;
using PCT.Domain.PersonalValue.RepositoryContracts;
using PCT.WebAPI.Controllers.Common;

namespace PCT.WebAPI.Controllers.PersonalValue;

public class PersonalValueController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IPersonalValueRepository _personalValueRepository;

    public PersonalValueController(IMediator mediator, IPersonalValueRepository personalValueRepository)
    {
        _mediator = mediator;
        _personalValueRepository = personalValueRepository;
    }

    [HttpPost("add")]
    [Authorize(Roles = "Coach")]
    public async Task<ActionResult<AddPersonalValueResponse>> Add(AddPersonalValueRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("getAll")]
    [Authorize(Roles = "Coach")]
    public async Task<ActionResult<List<GetAllPersonalValueResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllPersonalValueRequest(), cancellationToken);
        return Ok(response);
    }
}