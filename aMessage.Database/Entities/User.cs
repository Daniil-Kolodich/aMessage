using System.ComponentModel.DataAnnotations;

namespace aMessage.Database.Entities;

public class User : Entity
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    public IEnumerable<Chat> Chats { get; set; }
    public IEnumerable<Message> Messages { get; set; }
}