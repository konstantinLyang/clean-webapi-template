using CleanWebApiTemplate.Domain.Common;

namespace CleanWebApiTemplate.Domain.Models;

public sealed class Role : Entity<long>
{
    public string Name { get; set; }
    
    public ICollection<User> Users { get; set; } = [];
    
    public ICollection<Permission> Permissions { get; set; } = [];

    public Role(string name)
    {
        Name = name;
    }
}
