using System.ComponentModel.DataAnnotations;

namespace aMessage.Database.Entities;

public class Message : Entity
{
    [Required]
    public string Content { get; set; }
    
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}