namespace aMessage.Database.Entities;

public class Chat : Entity
{
    public string Name { get; set; }
    public IEnumerable<User> Users { get; set; }
    public IEnumerable<Message> Messages { get; set; }
}