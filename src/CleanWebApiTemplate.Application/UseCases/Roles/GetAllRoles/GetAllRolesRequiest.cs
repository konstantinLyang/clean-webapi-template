using CleanWebApiTemplate.Domain.Models;
using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Roles.GetAllRoles;

public sealed record GetAllRolesRequest : IRequest<IEnumerable<RoleDto>>;