namespace Domain.Entities;

public class OrderEntity
    : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public int StatusId { get; set; }

    public DateTime TakenFrom { get; set; }
    public DateTime TakenTo { get; set; }

    public UserEntity User { get; set; } = default!;
    public BookEntity Book { get; set; } = default!;
    public OrderStatusEntity Status { get; set; } = default!;
}