namespace Domain.Entities;

public class AuthorEntity
    : BaseEntity<int>
{
    public string PicturePath { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;


    public List<BookEntity> Books { get; set; } = [];
}