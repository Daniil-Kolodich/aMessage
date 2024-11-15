using aMessage.Database.Repositories;
using aMessage.Domain.Authentication.Models;

namespace aMessage.Domain.Authentication.Services.Concrete;

public class AuthenticationService(IUserRepository userRepository) : IAuthenticationService
{
    public async Task<AuthenticationResponse?> Register(string userName, string email, string password)
    {
        var user = await userRepository.CreateUser(userName, email, password);

        if (user is null)
            return null;

        return new AuthenticationResponse(
            new UserResponse(user.Id, user.CreatedAt, user.UpdatedAt, user.IsDeleted, user.Username, user.Email),
            "JwtToken");
    }

    public async Task<AuthenticationResponse?> Login(string email, string password)
    {
        var user = await userRepository.FindUser(email, password);

        if (user is null)
            return null;
        
        return new AuthenticationResponse(
            new UserResponse(user.Id, user.CreatedAt, user.UpdatedAt, user.IsDeleted, user.Username, user.Email),
            "JwtToken");
    }
}