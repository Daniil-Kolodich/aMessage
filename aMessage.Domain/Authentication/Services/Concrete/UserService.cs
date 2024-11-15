using aMessage.Database;
using User = aMessage.Database.Entities.User;

namespace aMessage.Domain.Authentication.Services.Concrete;

public class UserService : IUserService
{
    private DatabaseContext _context;

    public UserService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<User> Register(string userName, string email, string password)
    {
        var user = _context.Set<User>().Add(new User()
        {
            Username = userName,
            Email = email,
            Password = password
        });

        await _context.SaveChangesAsync();
        return user.Entity;
    }
}