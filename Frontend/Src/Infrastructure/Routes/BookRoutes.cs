namespace Infrastructure.Routes;

public static class BookRoutes
{
    private const string BaseUrl = "api/common/book";
    
    public static string GetPaginatedBooks(
        int pageNumber, int pageSize, string? searchTerms) =>
        BaseUrl +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}";
}