using aMessage.Database.Entities;

namespace aMessage.Domain.Chats;

public interface IChatsService
{
    Task<Chat?> StartChat(string name, params int[] userIds);
    Task<IEnumerable<Chat>> GetAll(int userId);
}