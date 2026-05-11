namespace CleanWebApiTemplate.Application.UseCases.Permissions;

public sealed record PermissionDto
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
}