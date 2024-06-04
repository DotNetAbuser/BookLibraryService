namespace Domain.Entities;

public class ReviewEntity
    : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    
    public string Content { get; set; } = string.Empty;
    public int Grade { get; set; }

    public UserEntity User { get; set; } = default!;
}