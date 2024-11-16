using aMessage.Domain.Authentication.Services;
using aMessage.Domain.Users;
using aMessage.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aMessage.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUsersService _usersService;
    private readonly IJwtHelper _jwtHelper;
    
    public UsersController(IAuthenticationService authenticationService, IJwtHelper jwtHelper, IUsersService usersService)
    {
        _authenticationService = authenticationService;
        _jwtHelper = jwtHelper;
        _usersService = usersService;
    }

    [HttpGet("find")]
    [Authorize]
    public async Task<IActionResult> GetUser(string name)
    {
        var users = await _usersService.FindUser(name);

        return Ok(users);
    }

    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(string userName, string email, string password)
    {
        var user = await _authenticationService.Register(userName, email, password);

        if (user is null)
            return BadRequest("Error occured");

        return Ok(new
        {
            User = user,
            JWT = _jwtHelper.GenerateToken(user.Id)
        });
    }
    
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _authenticationService.Login(email, password);

        if (user is null)
            return BadRequest("Error occured");

        return Ok(new
        {
            User = user,
            JWT = _jwtHelper.GenerateToken(user.Id)
        });
    }
}