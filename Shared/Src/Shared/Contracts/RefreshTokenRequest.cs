namespace Shared.Contracts;

public record RefreshTokenRequest(
    string AuthToken,
    string RefreshToken);