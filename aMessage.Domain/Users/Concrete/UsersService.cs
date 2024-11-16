using aMessage.Database.Repositories;
using aMessage.Domain.Authentication.Models;

namespace aMessage.Domain.Users.Concrete;

public class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;

    public UsersService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserResponse>> FindUser(string partialName)
    {
        var users = await _userRepository.FindUser(partialName);

        return users.Select(u => (UserResponse)u);
    }
}