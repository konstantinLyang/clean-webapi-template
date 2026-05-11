namespace CleanWebApiTemplate.Application.UseCases.Roles;

public sealed record RoleDto
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
}