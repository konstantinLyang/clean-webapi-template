using CleanWebApiTemplate.Application.Abstractions.Data;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.UseCases.Users.GetAllUsers;

internal sealed class GetAllUsersRequestHandler(
    IAppDbContext dbContext
) : IRequestHandler<GetAllUsersRequest, IEnumerable<UserDto>>
{
    public async ValueTask<IEnumerable<UserDto>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        return await dbContext.Users
            .ProjectToType<UserDto>()
            .ToListAsync(cancellationToken);
    }
}