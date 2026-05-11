using Mediator;

namespace CleanWebApiTemplate.Application.UseCases.Users.GetUserById;

public sealed record GetUserByIdRequest(long UserId) : IRequest<UserDto>;