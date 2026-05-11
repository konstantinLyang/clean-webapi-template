using CleanWebApiTemplate.Domain.Common;

namespace CleanWebApiTemplate.Domain.Models;

public sealed class Permission : Entity<long>
{
    public required string Name { get; init; }

    public ICollection<Role> Roles { get; set; } = [];
}
