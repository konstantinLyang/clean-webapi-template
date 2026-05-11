namespace CleanWebApiTemplate.Domain.Exceptions;

/// <summary>
/// Exception thrown when input data violates validation or business rules.
/// </summary>
public sealed class ValidationException : DomainException
{
    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
    
    public ValidationException(string message) : base(message)
    {
        
    }
}
