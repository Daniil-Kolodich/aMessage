using aMessage.Database.Entities;
using aMessage.Domain.Authentication.Models;

namespace aMessage.Domain.Users;

public interface IUsersService
{
    Task<IEnumerable<UserResponse>> FindUser(string partialName);
}