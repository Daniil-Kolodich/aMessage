using aMessage.Domain.Authentication.Models;

namespace aMessage.Domain.Authentication.Services;

public interface IAuthenticationService
{
    Task<UserResponse?> Register(string userName, string email, string password);
    Task<UserResponse?> Login(string email, string password);
}