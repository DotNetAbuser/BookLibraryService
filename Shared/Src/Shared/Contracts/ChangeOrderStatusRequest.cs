namespace Shared.Contracts;

public class ChangeOrderStatusRequest
{
    [Range(1, Int32.MaxValue, ErrorMessage = "Статус не может быть не выбран!")] public int StatusId { get; set; }
}