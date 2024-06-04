namespace Application.IServices;

public interface ITokenService
{
    Task<Result<SignInResponse>> SignInAsync(SignInRequest request);
    Task<Result<SignInResponse>> RefreshTokenAsync(RefreshTokenRequest request);
}