using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Roles.CreateRole;

public sealed record CreateRoleCommand(string Name) : ICommand;