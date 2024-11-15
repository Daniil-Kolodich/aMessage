namespace aMessage.Domain.Authentication.Models;

public record AuthenticationResponse(UserResponse User, string JwtToken);


