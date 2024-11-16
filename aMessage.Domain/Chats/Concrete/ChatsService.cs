using aMessage.Database.Entities;
using aMessage.Database.Repositories;

namespace aMessage.Domain.Chats.Concrete;

public class ChatsService : IChatsService
{
    private readonly IChatRepository _chatRepository;

    public ChatsService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<Chat?> StartChat(string name, params int[] userIds)
    {
        return await _chatRepository.AddChat(name, userIds);
    }

    public async Task<IEnumerable<Chat>> GetAll(int userId)
    {
        return await _chatRepository.GetChats(userId);
    }
}