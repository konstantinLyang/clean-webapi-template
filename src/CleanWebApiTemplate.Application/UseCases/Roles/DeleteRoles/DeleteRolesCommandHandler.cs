using CleanWebApiTemplate.Application.Abstractions.Data;
using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Roles.DeleteRoles;

internal sealed class DeleteRolesCommandHandler(
    IAppDbContext dbContext
) : ICommandHandler<DeleteRolesCommand>
{
    public async ValueTask<Unit> Handle(DeleteRolesCommand command, CancellationToken cancellationToken)
    {
        var activeRoles = dbContext.Roles
            .Where(x => command.RoleIds.Contains(x.Id));
        
        foreach (var activeRole in activeRoles)
            activeRole.IsDeleted = true;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}