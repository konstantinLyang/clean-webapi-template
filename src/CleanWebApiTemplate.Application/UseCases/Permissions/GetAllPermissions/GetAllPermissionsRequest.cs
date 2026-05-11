using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Permissions.GetAllPermissions;

public sealed record GetAllPermissionsRequest : IRequest<IEnumerable<PermissionDto>>;