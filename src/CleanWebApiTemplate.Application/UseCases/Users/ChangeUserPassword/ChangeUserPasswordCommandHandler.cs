using CleanWebApiTemplate.Application.Abstractions.Data;
using CleanWebApiTemplate.Application.Abstractions.Security;
using CleanWebApiTemplate.Domain.Exceptions;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.UseCases.Users.ChangeUserPassword;

internal sealed class ChangeUserPasswordCommandHandler(
    IAppDbContext dbContext,
    IPasswordHasher passwordHasher
) : ICommandHandler<ChangeUserPasswordCommand>
{
    public async ValueTask<Unit> Handle(ChangeUserPasswordCommand command, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(x => x.IsDeleted != true && x.Id == command.UserId, cancellationToken)
            ?? throw new NotFoundException("User not found");

        var currentPasswordIsValid = passwordHasher.Verify(command.CurrentPassword, user.PasswordHash);

        if (!currentPasswordIsValid)
            throw new ValidationException("Current password is invalid");

        user.PasswordHash = passwordHasher.Hash(command.NewPassword);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
