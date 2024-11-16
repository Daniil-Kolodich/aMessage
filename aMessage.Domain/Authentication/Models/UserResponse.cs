using aMessage.Database.Entities;

namespace aMessage.Domain.Authentication.Models;

public record UserResponse(
    int Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    bool IsDeleted,
    string UserName,
    string Email)
{
    public static implicit operator UserResponse(User user) => 
        new UserResponse(user.Id, user.CreatedAt, user.UpdatedAt, user.IsDeleted, user.Username, user.Email);
}
