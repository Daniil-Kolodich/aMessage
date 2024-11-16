using aMessage.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace aMessage.Database.Repositories.Concrete;

public class ChatRepository : IChatRepository
{
    private readonly DatabaseContext _context;

    public ChatRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Chat?> AddChat(string name, params int[] userIds)
    {
        var users = await _context.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();
        
        var chat = _context.Chats.Add(new Chat()
        {
            CreatedAt = DateTime.Now,
            Name = name,
            Users = users
        }).Entity;

        await _context.SaveChangesAsync();

        return chat;
    }

    public async Task<IEnumerable<Chat>> GetChats(int userId)
    {
        // TODO: investigate generated query to improve performance 
        return await _context.Chats.AsNoTracking()
            .Include(c => c.Users)
            .Where(c => c.Users.Any(u => u.Id == userId)).ToListAsync();
    }

    public Task<Chat?> RenameChat(int id, string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteChat(int id)
    {
        throw new NotImplementedException();
    }
}