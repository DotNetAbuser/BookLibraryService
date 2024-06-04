namespace Shared.Contracts;

public record ReviewResponse(
    Guid Id,
    string UserPicturePath,
    string Username,
    string Content,
    int Grade);