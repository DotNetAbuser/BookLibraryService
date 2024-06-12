namespace Shared.Contracts;

public class UpdateBookRequest
{ 
    public UploadRequest? BookPictureRequest { get; set; }
    [Range(1, Int32.MaxValue, ErrorMessage = "Автор книги должен быть выбран!")] public int AuthorId { get; set; }
    [Range(1, Int32.MaxValue, ErrorMessage = "Жанр книги должен быть выбран!")] public int GenreId { get; set; }
    [Required(ErrorMessage = "У книги должно быть название!")] public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "К книге должно быть описание!")] public string Description { get; set; } = string.Empty;
    [Range(1900, Int32.MaxValue, ErrorMessage = "Книги ниже 1900 года не могут быть добавлены")] public int Year { get; set; }
    [Range(0, Int32.MaxValue,ErrorMessage = "Кол-во книг не может быть отрицательным!")] public int Quantity { get; set; }
}