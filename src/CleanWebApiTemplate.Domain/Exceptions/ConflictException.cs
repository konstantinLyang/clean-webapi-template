namespace CleanWebApiTemplate.Domain.Exceptions;

/// <summary>
/// Exception thrown when an operation conflicts with existing state, such as duplicate unique data.
/// </summary>
public sealed class ConflictException : DomainException
{
    public ConflictException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
    
    public ConflictException(string message) : base(message)
    {
        
    }
}
