using Abacush.Application.ObjectTypes.Commands;
using Abacush.Application.ObjectTypes.Dtos;
using Abacush.Application.ObjectTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abacush.Api.Controllers;

[ApiController]
[Route("api/[controller]/types")]
public sealed class PermissionsController : ControllerBase
{
    private readonly ISender _sender;

    public PermissionsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ObjectTypeResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ObjectTypeResponse>>> GetAll(
        CancellationToken cancellationToken)
    {
        var objectTypes = await _sender.Send(new GetObjectTypesQuery(), cancellationToken);
        return Ok(objectTypes);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ObjectTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ObjectTypeResponse>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var objectType = await _sender.Send(new GetObjectTypeByIdQuery(id), cancellationToken);
        return objectType is null ? NotFound() : Ok(objectType);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ObjectTypeResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<ObjectTypeResponse>> Create(
        CreateObjectTypeRequest request,
        CancellationToken cancellationToken)
    {
        var objectType = await _sender.Send(new CreateObjectTypeCommand(request), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = objectType.Id }, objectType);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ObjectTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ObjectTypeResponse>> Update(
        Guid id,
        UpdateObjectTypeRequest request,
        CancellationToken cancellationToken)
    {
        var objectType = await _sender.Send(new UpdateObjectTypeCommand(id, request), cancellationToken);
        return objectType is null ? NotFound() : Ok(objectType);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _sender.Send(new DeleteObjectTypeCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
