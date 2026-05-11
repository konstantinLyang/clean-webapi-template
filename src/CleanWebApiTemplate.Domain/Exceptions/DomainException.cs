namespace CleanWebApiTemplate.Domain.Exceptions;

/// <summary>
/// Base exception for expected domain and application rule failures.
/// </summary>
public class DomainException : Exception
{
    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
    
    public DomainException(string message) : base(message)
    {
        
    }
}
