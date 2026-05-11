using CleanWebApiTemplate.Application.Abstractions.Data;
using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Users.DeleteUsers;

public sealed class DeleteUsersCommandHandler(
    IAppDbContext dbContext
) : ICommandHandler<DeleteUsersCommand>
{
    public async ValueTask<Unit> Handle(DeleteUsersCommand command, CancellationToken cancellationToken)
    {
        var existsUsers = dbContext.Users.Where(x => command.UsersIds.Contains(x.Id));

        foreach (var user in existsUsers)
            user.IsDeleted = true;
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}