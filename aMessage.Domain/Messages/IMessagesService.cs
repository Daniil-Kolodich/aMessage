using aMessage.Database.Entities;

namespace aMessage.Domain.Messages;

public interface IMessagesService
{
    Task<Message?> SendMessage(int chatId, int userId, string content);
}