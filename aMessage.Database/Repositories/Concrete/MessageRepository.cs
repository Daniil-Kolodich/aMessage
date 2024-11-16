using aMessage.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace aMessage.Database.Repositories.Concrete;

public class MessageRepository : IMessageRepository
{
    private readonly DatabaseContext _context;

    public MessageRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Message>> GetMessages(int chatId)
    {
        return await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();
    }

    public async Task<Message?> AddMessage(int chatId, int userId, string content)
    {
        var user = await _context.Users.FindAsync(userId);
        var chat = await _context.Chats.FindAsync(chatId);

        if (user is null || chat is null)
            return null;
        
        var message = (await _context.Messages.AddAsync(new Message()
        {
            CreatedAt = DateTime.Now,
            Content = content,
            User = user,
            Chat = chat
        })).Entity;

        await _context.SaveChangesAsync();
        
        return message;
    }

    public Task<Message> UpdateMessage(int id, string content)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMessage(int id)
    {
        throw new NotImplementedException();
    }
}