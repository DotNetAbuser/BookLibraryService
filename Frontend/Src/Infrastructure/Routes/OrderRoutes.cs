namespace Infrastructure.Routes;

public static class OrderRoutes
{
    private const string BaseUrl = "api/orders";

    public static string GetPaginatedOrders(
        int pageNumber, int pageSize) =>
        BaseUrl +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}";
    
    public static string GetPaginatedOrdersByUserId(
        Guid id, int pageNumber, int pageSize) =>
        BaseUrl + $"/user/{id}" +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}";
    
    public static string GetPaginatedMyOrders(
        int pageNumber, int pageSize) =>
        BaseUrl + "/my-orders" +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}";

    public static string Create => BaseUrl;

    public static string Delete(Guid id) =>
        BaseUrl + $"/{id}";

    public static string ChangeOrderStatus(Guid id) =>
        BaseUrl + $"/{id}/status";

    public static string ExtendOrder(Guid id) =>
        BaseUrl + $"/{id}/extend";
    
    public static string GetCount => BaseUrl + "/count";

}