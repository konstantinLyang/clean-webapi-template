namespace CleanWebApiTemplate.Application.Abstractions.Security;

public interface ISensitiveDataProtector
{
    string Protect(string value);
    
    string Unprotect(string value);
}