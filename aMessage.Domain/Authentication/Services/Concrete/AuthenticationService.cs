using aMessage.Database.Repositories;
using aMessage.Domain.Authentication.Models;

namespace aMessage.Domain.Authentication.Services.Concrete;

public class AuthenticationService(IUserRepository userRepository) : IAuthenticationService
{
    public async Task<UserResponse?> Register(string userName, string email, string password)
    {
        var user = await userRepository.CreateUser(userName, email, password);

        if (user is null)
            return null;

        return new UserResponse(user.Id, user.CreatedAt, user.UpdatedAt, user.IsDeleted, user.Username, user.Email);
    }

    public async Task<UserResponse?> Login(string email, string password)
    {
        var user = await userRepository.FindUser(email, password);

        if (user is null)
            return null;
        
        return new UserResponse(user.Id, user.CreatedAt, user.UpdatedAt, user.IsDeleted, user.Username, user.Email);
    }
}