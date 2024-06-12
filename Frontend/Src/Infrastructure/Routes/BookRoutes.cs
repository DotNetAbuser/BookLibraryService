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

    public static string? GetById(Guid id) => BaseUrl + $"/{id}";

    public static string Create => BaseUrl;

    public static string Update(Guid id) =>
        BaseUrl + $"/{id}";

    public static string Delete(Guid id) =>
        BaseUrl + $"/{id}";

    public static string GetCount => BaseUrl + "/count";
}