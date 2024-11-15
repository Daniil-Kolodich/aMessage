using aMessage.Database.Entities;

namespace aMessage.Database.Repositories;

public interface IUserRepository
{
    // user domain
    Task<User?> CreateUser(string userName, string email, string password);
    Task<User?> UpdateUser(int id, string? userName = null, string? email = null, string? password = null);
    Task<User?> FindUser(string email, string password);
    Task<bool> DeleteUser(int id);
}