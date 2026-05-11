namespace CleanWebApiTemplate.Domain.Common;

public abstract class Entity<T>
{
    public T Id { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    
    public DateTimeOffset UpdatedAt { get; set; }
}
