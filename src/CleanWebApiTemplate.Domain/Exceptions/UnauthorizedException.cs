namespace CleanWebApiTemplate.Domain.Exceptions;

/// <summary>
/// Exception thrown when the caller must be authenticated before performing the operation.
/// </summary>
public sealed class UnauthorizedException : DomainException
{
    public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
    
    public UnauthorizedException(string message) : base(message)
    {
        
    }
}
