namespace Shared.Contracts;

public class CreateOrderRequest
{

    public Guid BookId { get; set; }

    public DateTime TakenFrom { get; set; } = DateTime.Now.AddHours(2);
    public DateTime TakenTo { get; set; } = DateTime.Now.AddDays(7).AddHours(2);
}