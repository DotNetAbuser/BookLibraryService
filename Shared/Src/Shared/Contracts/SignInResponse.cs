namespace Shared.Contracts;

public record SignInResponse(
    string AuthToken,
    string RefreshToken);