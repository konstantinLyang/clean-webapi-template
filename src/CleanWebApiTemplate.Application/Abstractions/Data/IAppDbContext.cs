using CleanWebApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Application.Abstractions.Data;

public interface IAppDbContext
{
    public DbSet<User> Users { get; }
    
    public DbSet<Role> Roles { get; }
    
    public DbSet<Permission> Permissions { get; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}