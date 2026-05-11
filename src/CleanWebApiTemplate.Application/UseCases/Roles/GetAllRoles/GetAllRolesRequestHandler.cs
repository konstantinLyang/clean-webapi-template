using CleanWebApiTemplate.Application.Abstractions.Data;
using CleanWebApiTemplate.Domain.Models;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.UseCases.Roles.GetAllRoles;

internal sealed class GetAllRolesRequestHandler(
    IAppDbContext dbContext
) : IRequestHandler<GetAllRolesRequest, IEnumerable<RoleDto>>
{
    public async ValueTask<IEnumerable<RoleDto>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        => await dbContext.Roles
            .ProjectToType<RoleDto>()
            .ToArrayAsync(cancellationToken);
}