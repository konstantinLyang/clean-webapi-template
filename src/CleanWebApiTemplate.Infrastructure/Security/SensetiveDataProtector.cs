using CleanWebApiTemplate.Application.Abstractions.Security;
using Microsoft.AspNetCore.DataProtection;

namespace CleanWebApiTemplate.Infrastructure.Security;

public sealed class SensitiveDataProtector : ISensitiveDataProtector
{
    private readonly IDataProtector _protector;

    public SensitiveDataProtector(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector("SensitiveData.v1");
    }
    
    public string Protect(string plainText)
    {
        return _protector.Protect(plainText);
    }

    public string Unprotect(string protectedText)
    {
        return _protector.Unprotect(protectedText);
    }
}