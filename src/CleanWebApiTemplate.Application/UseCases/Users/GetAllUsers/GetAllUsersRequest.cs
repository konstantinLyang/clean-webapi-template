using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Users.GetAllUsers;

public sealed record GetAllUsersRequest : IRequest<IEnumerable<UserDto>>;
