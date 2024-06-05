namespace Shared.Contracts;

public record OrderResponse(
    Guid Id,
    string Username,
    string BookTitle,
    string Status,
    DateTime TakenFrom,
    DateTime TakenTo,
    DateTime Created);