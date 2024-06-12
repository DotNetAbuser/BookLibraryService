namespace Infrastructure.Routes;

public static class ReviewRoutes
{
    private const string BaseUrl = "api/review";

    public static string GetPaginatedReviewsAsync(
        int pageNumber, int pageSize) =>
        BaseUrl + 
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}";

    public static string Create => BaseUrl;
    
    public static string GetCount => BaseUrl + "/count";

}