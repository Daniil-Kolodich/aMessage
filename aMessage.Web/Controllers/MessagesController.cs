using aMessage.Database.Repositories;
using aMessage.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aMessage.Web.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;
    private readonly IIdentityService _identityService;
    
    public MessagesController(IMessageRepository messageRepository, IIdentityService identityService)
    {
        _messageRepository = messageRepository;
        _identityService = identityService;
    }

    [HttpPost("Send")]
    public async Task<IActionResult> SendMessage(int chatId, string content)
    {
        var message = await _messageRepository.AddMessage(chatId, _identityService.UserId, content);
        
        if (message is null)
            return BadRequest("Unable to send message");

        return Ok(message);
    }

    [HttpGet(":id")]
    public async Task<IActionResult> GetChatMessages(int chatId)
    {
        var messages = await _messageRepository.GetMessages(chatId);

        return Ok(messages);
    }
}