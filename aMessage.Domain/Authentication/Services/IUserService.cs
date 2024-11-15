using User = aMessage.Database.Entities.User;

namespace aMessage.Domain.Authentication.Services;

public interface IUserService
{
    Task<User> Register(string userName, string email, string password);
}