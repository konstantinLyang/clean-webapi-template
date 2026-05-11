using CleanWebApiTemplate.Application.Abstractions.Data;
using CleanWebApiTemplate.Domain.Exceptions;
using CleanWebApiTemplate.Domain.Models;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.UseCases.Roles.CreateRole;

internal sealed class CreateRoleCommandHandler(
    IAppDbContext dbContext
) : ICommandHandler<CreateRoleCommand>
{
    public async ValueTask<Unit> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
    {
        var existsRole = await dbContext.Roles.FirstOrDefaultAsync(x => x.Name == command.Name, cancellationToken);

        if (existsRole is not null)
            throw new ConflictException("Role already exists");

        await dbContext.Roles.AddAsync(new Role(command.Name), cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
