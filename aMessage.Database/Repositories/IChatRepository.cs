using aMessage.Database.Entities;

namespace aMessage.Database.Repositories;

public interface IChatRepository
{
    Task<Chat?> AddChat(string name, params int[] userIds);
    Task<IEnumerable<Chat>> GetChats(int userId);
    Task<Chat?> RenameChat(int id, string name);
    Task<bool> DeleteChat(int id);
}