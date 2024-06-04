namespace Domain.Entities;

public class GenreEntity
    : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;

    public List<BookEntity> Books { get; set; } = [];
}