namespace Shared.Contracts;

public class CreateBookRequest
{
    [Required] public UploadRequest BookPictureRequest { get; set; } = default!;
    [Required] public string Title { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
    [Range(1, Int32.MaxValue)] public int AuthorId { get; set; }
    [Range(1, Int32.MaxValue)] public int GenreId { get; set; }
    [Range(1900, Int32.MaxValue)] public int Year { get; set; }
    [Range(0, Int32.MaxValue)] public int Quantity { get; set; }
}