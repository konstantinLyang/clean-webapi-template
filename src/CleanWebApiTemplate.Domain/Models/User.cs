using CleanWebApiTemplate.Domain.Common;

namespace CleanWebApiTemplate.Domain.Models;

public sealed class User : Entity<long>
{
    /// <summary>
    /// User email.
    /// </summary>
    public required string Email { get; set; }
    
    /// <summary>
    /// User hashed password data.
    /// </summary>
    public required string PasswordHash { get; set; }
    
    /// <summary>
    /// User first name.
    /// </summary>
    public string? FirstName { get; set; }
    
    /// <summary>
    /// User last name.
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// User roles.
    /// </summary>
    public ICollection<Role> Roles { get; set; } = [];
}