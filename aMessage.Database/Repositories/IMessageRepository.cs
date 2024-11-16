using aMessage.Database.Entities;

namespace aMessage.Database.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetMessages(int chatId);
    Task<Message?> AddMessage(int chatId, int userId, string content);
    Task<Message?> UpdateMessage(int id, string content);
    Task<bool> DeleteMessage(int id);
}