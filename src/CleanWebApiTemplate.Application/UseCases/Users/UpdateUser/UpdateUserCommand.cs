using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Users.UpdateUser;

public sealed record UpdateUserCommand(
    long UserId,
    string Email,
    string? FirstName,
    string? LastName,
    IEnumerable<long> RoleIds
) : ICommand;
