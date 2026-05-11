using CleanWebApiTemplate.Application.Abstractions.Data;
using CleanWebApiTemplate.Domain.Exceptions;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.UseCases.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler(
    IAppDbContext dbContext
) : ICommandHandler<UpdateUserCommand>
{
    public async ValueTask<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.IsDeleted != true && x.Id == command.UserId, cancellationToken)
            ?? throw new NotFoundException("User not found");

        var userWithSameEmailExists = await dbContext.Users
            .AnyAsync(x => x.IsDeleted != true && x.Id != command.UserId && x.Email == command.Email, cancellationToken);

        if (userWithSameEmailExists)
            throw new ConflictException("User with same email already exists");

        var roleIds = command.RoleIds
            .Distinct()
            .ToArray();

        var roles = await dbContext.Roles
            .Where(x => x.IsDeleted != true && roleIds.Contains(x.Id))
            .ToListAsync(cancellationToken);

        if (roles.Count != roleIds.Length)
            throw new NotFoundException("One or more roles not found");

        user.Email = command.Email;
        user.FirstName = command.FirstName;
        user.LastName = command.LastName;

        user.Roles.Clear();

        foreach (var role in roles)
            user.Roles.Add(role);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
