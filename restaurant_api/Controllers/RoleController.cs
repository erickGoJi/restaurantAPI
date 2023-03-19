using MediatR;
using Microsoft.AspNetCore.Mvc;
using restaurant_api.Features.Role.Commands;
using restaurant_api.Features.Role.Model;
using restaurant_api.Features.Role.Queries;

namespace restaurant_api.Controllers;

[ApiController]
[Route("api/roles")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Consult roles
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<List<CatRolesQueryReponse>> GetRoles() => _mediator.Send(new GetRolesQuery());

    /// <summary>
    /// Create a new Role
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Consult Role by ID
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet("{ProductId}")]
    public Task<CatRoleQueryReponse> GetProductById([FromRoute] GetRoleQuery query) =>
        _mediator.Send(query);
}