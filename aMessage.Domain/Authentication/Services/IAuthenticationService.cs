using aMessage.Domain.Authentication.Models;

namespace aMessage.Domain.Authentication.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResponse?> Register(string userName, string email, string password);
    Task<AuthenticationResponse?> Login(string email, string password);
}