namespace aMessage.Domain.Authentication.Models;

public record UserResponse(
    int Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    bool IsDeleted,
    string UserName,
    string Email);
