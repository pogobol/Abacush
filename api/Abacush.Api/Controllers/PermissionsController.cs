using Abacush.Application.QualifiedTypes.Commands;
using Abacush.Application.QualifiedTypes.Dtos;
using Abacush.Application.QualifiedTypes.Queries;
using Abacush.Application.QualifiedSubjects.Commands;
using Abacush.Application.QualifiedSubjects.Dtos;
using Abacush.Application.QualifiedSubjects.Queries;
using Abacush.Application.QualifiedObjects.Commands;
using Abacush.Application.QualifiedObjects.Dtos;
using Abacush.Application.QualifiedObjects.Queries;
using Abacush.Application.Permissions.Commands;
using Abacush.Application.Permissions.Dtos;
using Abacush.Application.Permissions.Queries;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace Abacush.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PermissionsController : ControllerBase
{
    private readonly ICommandBus _bus;

    public PermissionsController(ICommandBus bus)
    {
        _bus = bus;
    }

    [HttpGet("types")]
    [ProducesResponseType(typeof(IReadOnlyList<QualifiedTypeResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<QualifiedTypeResponse>>> GetAll(
        CancellationToken cancellationToken)
    {
        var qualifiedTypes = await _bus.InvokeAsync<IReadOnlyList<QualifiedTypeResponse>>(new GetQualifiedTypesQuery(), cancellationToken);
        return Ok(qualifiedTypes);
    }

    [HttpGet("types/{id:guid}")]
    [ProducesResponseType(typeof(QualifiedTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QualifiedTypeResponse>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var qualifiedType = await _bus.InvokeAsync<QualifiedTypeResponse?>(new GetQualifiedTypeByIdQuery(id), cancellationToken);
        return qualifiedType is null ? NotFound() : Ok(qualifiedType);
    }

    [HttpPost("types")]
    [ProducesResponseType(typeof(QualifiedTypeResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<QualifiedTypeResponse>> Create(
        CreateQualifiedTypeRequest request,
        CancellationToken cancellationToken)
    {
        var qualifiedType = await _bus.InvokeAsync<QualifiedTypeResponse>(new CreateQualifiedTypeCommand(request), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = qualifiedType.Id }, qualifiedType);
    }

    [HttpPut("types/{id:guid}")]
    [ProducesResponseType(typeof(QualifiedTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QualifiedTypeResponse>> Update(
        Guid id,
        UpdateQualifiedTypeRequest request,
        CancellationToken cancellationToken)
    {
        var qualifiedType = await _bus.InvokeAsync<QualifiedTypeResponse?>(new UpdateQualifiedTypeCommand(id, request), cancellationToken);
        return qualifiedType is null ? NotFound() : Ok(qualifiedType);
    }

    [HttpDelete("types/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _bus.InvokeAsync<bool>(new DeleteQualifiedTypeCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpGet("subjects")]
    [ProducesResponseType(typeof(IReadOnlyList<QualifiedSubjectResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<QualifiedSubjectResponse>>> GetSubjects(
        CancellationToken cancellationToken)
    {
        var subjects = await _bus.InvokeAsync<IReadOnlyList<QualifiedSubjectResponse>>(new GetQualifiedSubjectsQuery(), cancellationToken);
        return Ok(subjects);
    }

    [HttpGet("subjects/{id:guid}")]
    [ProducesResponseType(typeof(QualifiedSubjectResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QualifiedSubjectResponse>> GetSubjectById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var subject = await _bus.InvokeAsync<QualifiedSubjectResponse?>(new GetQualifiedSubjectByIdQuery(id), cancellationToken);
        return subject is null ? NotFound() : Ok(subject);
    }

    [HttpPost("subjects")]
    [ProducesResponseType(typeof(QualifiedSubjectResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<QualifiedSubjectResponse>> CreateSubject(
        CreateQualifiedSubjectRequest request,
        CancellationToken cancellationToken)
    {
        var subject = await _bus.InvokeAsync<QualifiedSubjectResponse>(new CreateQualifiedSubjectCommand(request), cancellationToken);
        return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id }, subject);
    }

    [HttpPut("subjects/{id:guid}")]
    [ProducesResponseType(typeof(QualifiedSubjectResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QualifiedSubjectResponse>> UpdateSubject(
        Guid id,
        UpdateQualifiedSubjectRequest request,
        CancellationToken cancellationToken)
    {
        var subject = await _bus.InvokeAsync<QualifiedSubjectResponse?>(new UpdateQualifiedSubjectCommand(id, request), cancellationToken);
        return subject is null ? NotFound() : Ok(subject);
    }

    [HttpDelete("subjects/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSubject(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _bus.InvokeAsync<bool>(new DeleteQualifiedSubjectCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpGet("objects")]
    [ProducesResponseType(typeof(IReadOnlyList<QualifiedObjectResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<QualifiedObjectResponse>>> GetObjects(
        CancellationToken cancellationToken)
    {
        var qualifiedObjects = await _bus.InvokeAsync<IReadOnlyList<QualifiedObjectResponse>>(new GetQualifiedObjectsQuery(), cancellationToken);
        return Ok(qualifiedObjects);
    }

    [HttpGet("objects/{id:guid}")]
    [ProducesResponseType(typeof(QualifiedObjectResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QualifiedObjectResponse>> GetObjectById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var qualifiedObject = await _bus.InvokeAsync<QualifiedObjectResponse?>(new GetQualifiedObjectByIdQuery(id), cancellationToken);
        return qualifiedObject is null ? NotFound() : Ok(qualifiedObject);
    }

    [HttpPost("objects")]
    [ProducesResponseType(typeof(QualifiedObjectResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<QualifiedObjectResponse>> CreateObject(
        CreateQualifiedObjectRequest request,
        CancellationToken cancellationToken)
    {
        var qualifiedObject = await _bus.InvokeAsync<QualifiedObjectResponse>(new CreateQualifiedObjectCommand(request), cancellationToken);
        return CreatedAtAction(nameof(GetObjectById), new { id = qualifiedObject.Id }, qualifiedObject);
    }

    [HttpPut("objects/{id:guid}")]
    [ProducesResponseType(typeof(QualifiedObjectResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QualifiedObjectResponse>> UpdateObject(
        Guid id,
        UpdateQualifiedObjectRequest request,
        CancellationToken cancellationToken)
    {
        var qualifiedObject = await _bus.InvokeAsync<QualifiedObjectResponse?>(new UpdateQualifiedObjectCommand(id, request), cancellationToken);
        return qualifiedObject is null ? NotFound() : Ok(qualifiedObject);
    }

    [HttpDelete("objects/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteObject(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _bus.InvokeAsync<bool>(new DeleteQualifiedObjectCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PermissionResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PermissionResponse>>> GetPermissions(
        CancellationToken cancellationToken)
    {
        var permissions = await _bus.InvokeAsync<IReadOnlyList<PermissionResponse>>(new GetPermissionsQuery(), cancellationToken);
        return Ok(permissions);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PermissionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermissionResponse>> GetPermissionById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var permission = await _bus.InvokeAsync<PermissionResponse?>(new GetPermissionByIdQuery(id), cancellationToken);
        return permission is null ? NotFound() : Ok(permission);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PermissionResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<PermissionResponse>> CreatePermission(
        CreatePermissionRequest request,
        CancellationToken cancellationToken)
    {
        var permission = await _bus.InvokeAsync<PermissionResponse>(new CreatePermissionCommand(request), cancellationToken);
        return CreatedAtAction(nameof(GetPermissionById), new { id = permission.Id }, permission);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(PermissionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PermissionResponse>> UpdatePermission(
        Guid id,
        UpdatePermissionRequest request,
        CancellationToken cancellationToken)
    {
        var permission = await _bus.InvokeAsync<PermissionResponse?>(new UpdatePermissionCommand(id, request), cancellationToken);
        return permission is null ? NotFound() : Ok(permission);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePermission(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _bus.InvokeAsync<bool>(new DeletePermissionCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
