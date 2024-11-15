namespace aMessage.Domain.Authentication.Models;

public class User
{
    public int Id { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
    public bool IsDeleted { get; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}