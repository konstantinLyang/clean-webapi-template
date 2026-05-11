using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Users.DeleteUsers;

public sealed record DeleteUsersCommand(IEnumerable<long> UsersIds) : ICommand;