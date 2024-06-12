namespace Infrastructure.Routes;

public static class AuthorRoutes
{
    private const string BaseUrl = "api/common/author";
    
    public static string GetPaginatedAuthors(
        int pageNumber, int pageSize) =>
        BaseUrl + "/paginated" +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}";

    public static string GetAllAsync => BaseUrl;
}