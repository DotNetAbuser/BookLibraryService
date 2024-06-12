namespace Infrastructure.Services;

public class UserService(
    IUserRepository userRepository)
    : IUserService
{
    public async Task<Result<int>> GetCountAsync()
    {
        var usersCount = await userRepository.GetCountAsync();
        return Result<int>.Success(usersCount,"Кол-во пользователей в системе успешно получены.");
    }

    public async Task<Result> CreateAsync(SignUpRequest request)
    {
        var isExistByEmail = await userRepository.IsExistByEmailAsync(
            request.Email);
        if (isExistByEmail)
            return Result<string>.Fail("Пользователь с данной почтой уже сущетсвует!");
        
        var isExistByUsername = await userRepository.IsExistByUsernameAsync(
            request.Username);
        if (isExistByUsername)
            return Result<string>.Fail("Пользователь с данным именем уже существует");

        var userEntity = new UserEntity {
            RoleId = (int)Role.Guest,
            PicturePath = "Files//Images//ProfilePictures//0.png",
            Email = request.Email,
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password)
        };
        await userRepository.CreateAsync(userEntity);
        return Result<string>.Success("Пользователь успешно зарегистрирован.");
    }
}