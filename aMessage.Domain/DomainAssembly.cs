using aMessage.Database;
using aMessage.Domain.Authentication.Services;
using aMessage.Domain.Authentication.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace aMessage.Domain;

public static class DomainAssembly
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        DatabaseAssembly.ConfigureServices(services);
    }
}