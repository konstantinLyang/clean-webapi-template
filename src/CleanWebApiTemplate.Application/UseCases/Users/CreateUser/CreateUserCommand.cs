using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Users.CreateUser;

public sealed record CreateUserCommand(string Email, string Password, string? FirstName, string? LastName, IEnumerable<long> RoleIds) : ICommand<long>;