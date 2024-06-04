namespace Domain.Entities;

public class BookEntity
    : BaseEntity<Guid>
{
    public int AuthorId { get; set; }
    public int GenreId { get; set; }

    public string PicturePath { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public int Year { get; set; }
    public int Quantity { get; set; }

    public AuthorEntity Author { get; set; } = default!;
    public GenreEntity Genre { get; set; } = default!;

    public List<OrderEntity> Orders { get; set; } = [];
}