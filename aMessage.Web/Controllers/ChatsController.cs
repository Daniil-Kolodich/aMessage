using aMessage.Domain.Chats;
using aMessage.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aMessage.Web.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ChatsController : ControllerBase
{
    private readonly IIdentityService _identityService;
    private readonly IChatsService _chatsService;
    
    public ChatsController(IIdentityService identityService, IChatsService chatsService)
    {
        _identityService = identityService;
        _chatsService = chatsService;
    }

    [HttpPost]
    public async Task<IActionResult> StartChat(string name, int[] participants)
    {
        var result = await _chatsService.StartChat(name, [_identityService.UserId, ..participants]);

        if (result is null)
            return BadRequest("Something went wrong :(");
        
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetChats()
    {
        var result = await _chatsService.GetAll(_identityService.UserId);

        return Ok(result);
    }
}