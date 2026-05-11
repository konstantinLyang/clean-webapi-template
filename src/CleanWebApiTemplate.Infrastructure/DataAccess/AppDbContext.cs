using CleanWebApiTemplate.Application.Abstractions.Data;
using CleanWebApiTemplate.Domain.Common;
using CleanWebApiTemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanWebApiTemplate.Infrastructure.DataAccess;

public sealed class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Permission> Permissions { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
