using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Roles.DeleteRoles;

public sealed record DeleteRolesCommand(IEnumerable<long> RoleIds) : ICommand;