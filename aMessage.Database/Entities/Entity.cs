namespace aMessage.Database.Entities;

public abstract class Entity
{
    public int Id { get; private set; }
    public DateTime CreatedAt { get; internal set; }
    public DateTime? UpdatedAt { get; internal set; }
    public bool IsDeleted { get; internal set; }
}