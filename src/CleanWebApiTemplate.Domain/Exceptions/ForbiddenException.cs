namespace CleanWebApiTemplate.Domain.Exceptions;

/// <summary>
/// Exception thrown when the caller is authenticated but does not have permission to perform the operation.
/// </summary>
public sealed class ForbiddenException : DomainException
{
    public ForbiddenException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
    
    public ForbiddenException(string message) : base(message)
    {
        
    }
}
