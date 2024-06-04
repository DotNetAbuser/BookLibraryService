namespace Shared.Contracts;

public class SignUpRequest
{
    [Required(ErrorMessage = "Поле почта не может быть пустым!")]
    [EmailAddress(ErrorMessage = "Поле почта не соотвествует маске 'email@example.com'!")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Поле имя пользователя не может быть пустым!")] public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Поле пароль не может быть пустым!")] public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Поле подтверждение пароля не может быть пустым!")] 
    [Compare(nameof(Password), ErrorMessage = "Поле подтверждение пароля не совпадает с введённым паролем!")]
    public string ConfirmPassword { get; set; } = string.Empty;
}