using aMessage.Database;
using aMessage.Domain.Authentication.Services;
using aMessage.Domain.Authentication.Services.Concrete;
using aMessage.Domain.Chats;
using aMessage.Domain.Chats.Concrete;
using aMessage.Domain.Users;
using aMessage.Domain.Users.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace aMessage.Domain;

public static class DomainAssembly
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IChatsService, ChatsService>();
        
        DatabaseAssembly.ConfigureServices(services);
    }
}