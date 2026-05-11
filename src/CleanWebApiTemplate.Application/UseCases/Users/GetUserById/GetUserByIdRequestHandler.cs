using CleanWebApiTemplate.Application.Abstractions.Data;
using CleanWebApiTemplate.Domain.Exceptions;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.UseCases.Users.GetUserById;

internal sealed class GetUserByIdRequestHandler(
    IAppDbContext dbContext
) : IRequestHandler<GetUserByIdRequest, UserDto>
{
    public async ValueTask<UserDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(x => x.IsDeleted != true && x.Id == request.UserId, cancellationToken) 
            ?? throw new NotFoundException("User not found");
        
        return user.Adapt<UserDto>();
    }
}