namespace Shared.Contracts;

public class UpdateBookRequest
{
    [Required] public UploadRequest BookPictureRequest { get; set; } = default!;
    [Range(1, Int32.MaxValue)] public int AuthorId { get; set; }
    [Range(1, Int32.MaxValue)] public int GenreId { get; set; }
    [Required] public string Title { get; set; } = string.Empty;

    [Required] public string Description { get; set; } = string.Empty;
    [Range(1900, Int32.MaxValue)] public int Year { get; set; }
    [Range(0, Int32.MaxValue)] public int Quantity { get; set; }
}