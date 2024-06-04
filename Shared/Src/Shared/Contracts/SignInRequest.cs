namespace Shared.Contracts;

public class SignInRequest
{
    [Required(ErrorMessage = "Поле имя пользователя не может быть пустым!")] public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Поле пароль не может быть пустым!")] public string Password { get; set; } = string.Empty;
}