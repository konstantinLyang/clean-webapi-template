using CleanWebApiTemplate.Application.Abstractions.Data;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.UseCases.Permissions.GetAllPermissions;

internal sealed class GetAllPermissionsRequestHandler(
    IAppDbContext dbContext
) : IRequestHandler<GetAllPermissionsRequest, IEnumerable<PermissionDto>>
{
    public async ValueTask<IEnumerable<PermissionDto>> Handle(GetAllPermissionsRequest request, CancellationToken cancellationToken)
    {
        return await dbContext.Permissions
            .ProjectToType<PermissionDto>()
            .ToArrayAsync(cancellationToken);
    }
}