namespace aMessage.Web.Helpers;

public interface IJwtHelper
{
    string GenerateToken(int userId);
}