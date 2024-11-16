using aMessage.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace aMessage.Database.Repositories.Concrete;

public class UserRepository : IUserRepository
{
    private DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> FindUser(string partialName)
    {
        return await _context.Users
            .AsNoTracking()
            .Where(u => u.Username.Contains(partialName))
            .ToListAsync();
    }


    public async Task<User?> CreateUser(string userName, string email, string password)
    {
        var user = (await _context.Users.AddAsync(new User
        {
            CreatedAt = DateTime.Now,
            IsDeleted = false,
            UpdatedAt = null,
            Username = userName,
            Email = email,
            Password = password
        })).Entity; 
        
        await _context.SaveChangesAsync();
        
        return user;
    }

    public async Task<User?> UpdateUser(int id, string? userName = null, string? email = null, string? password = null)
    {
        var userToUpdate = await _context.Users.FindAsync(id);

        if (userToUpdate is null)
            return null;
        
        if (userName is not null)
            userToUpdate.Username = userName;
        
        if (email is not null)
            userToUpdate.Email = email;
        
        if (password is not null)
            userToUpdate.Password = password;
        
        userToUpdate.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        return userToUpdate;
    }

    public async Task<User?> FindUser(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var userToDelete = await _context.Users.FindAsync(id);

        if (userToDelete is null)
            return false;

        userToDelete.IsDeleted = true;
        // soft delete
        _context.Users.Update(userToDelete);
        return await _context.SaveChangesAsync() > 0;
    }
}