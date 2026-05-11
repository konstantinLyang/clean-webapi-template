using CleanWebApiTemplate.Application.Abstractions.Data;
using CleanWebApiTemplate.Application.Abstractions.Security;
using CleanWebApiTemplate.Domain.Exceptions;
using CleanWebApiTemplate.Domain.Models;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.UseCases.Users.CreateUser;

internal sealed class CreateUserCommandHandler(
    IAppDbContext dbContext,
    IPasswordHasher passwordHasher
) : ICommandHandler<CreateUserCommand, long>
{
    public async ValueTask<long> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var existsUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == command.Email, cancellationToken);

        if (existsUser is not null)
            throw new ConflictException("User already exists");

        var passwordHash = passwordHasher.Hash(command.Password);

        var roles = await dbContext.Roles.Where(x => command.RoleIds.Contains(x.Id)).ToListAsync(cancellationToken);
        
        var newUser = new User
        {
            Email = command.Email,
            PasswordHash = passwordHash,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Roles = roles
        };
        
        await dbContext.Users.AddAsync(newUser, cancellationToken);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return newUser.Id; 
    }
}
