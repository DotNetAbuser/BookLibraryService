namespace Shared.Contracts;

public class OrderResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string BookTitle { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime TakenFrom { get; set; }
    public DateTime TakenTo { get; set; }
    public DateTime Created { get; set; }
}
