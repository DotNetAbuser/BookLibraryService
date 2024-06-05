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
}