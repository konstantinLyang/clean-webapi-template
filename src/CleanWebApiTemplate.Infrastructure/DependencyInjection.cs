using CleanWebApiTemplate.Application.Abstractions.Security;
using CleanWebApiTemplate.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace CleanWebApiTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        
        services.AddDataProtection();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ISensitiveDataProtector, SensitiveDataProtector>();
        
        return services;
    }
}