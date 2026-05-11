using CleanWebApiTemplate.Application.UseCases.Roles;

namespace CleanWebApiTemplate.Application.UseCases.Users;

public sealed record UserDto
{
    public long Id { get; init; }

    public string Email { get; init; } = string.Empty;
    
    public string FirstName { get; init; }= string.Empty;
   
    public string LastName { get; init; }= string.Empty;
    
    public DateTimeOffset CreatedAt { get; init; }
    
    public DateTimeOffset UpdatedAt { get; init; }
    
    public bool IsDeleted { get; init; }

    public IEnumerable<RoleDto> Roles { get; init; } = [];
}