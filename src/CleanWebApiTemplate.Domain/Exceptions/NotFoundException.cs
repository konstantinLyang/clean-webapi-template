namespace CleanWebApiTemplate.Domain.Exceptions;

/// <summary>
/// Exception thrown when a requested entity or resource does not exist.
/// </summary>
public sealed class NotFoundException : DomainException
{
    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
    
    public NotFoundException(string message) : base(message)
    {
        
    }
}
