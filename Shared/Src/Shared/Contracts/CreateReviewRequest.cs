namespace Shared.Contracts;

public class CreateReviewRequest
{
    [Required(ErrorMessage = "Поле текст отзыва не может быть пустым!")] public string Content { get; set; } = string.Empty;
    [Range(1, 5, ErrorMessage = "Необходимо поставить оценку!") ]public int Grade { get; set; } 
}