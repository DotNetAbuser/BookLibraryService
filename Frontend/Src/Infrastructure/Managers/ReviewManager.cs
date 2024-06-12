namespace Infrastructure.Managers;

public interface IReviewManager
{
    Task<IResult<int>> GetCountAsync();
    
    Task<IResult<PaginatedData<ReviewResponse>>> GetPaginatedReviewsAsync(
        int pageNumber, int pageSize);

    Task<IResult> CreateAsync(CreateReviewRequest request);
}

public class ReviewManager(
    IHttpClientFactory factory)
    : IReviewManager
{
    public async Task<IResult<int>> GetCountAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(ReviewRoutes.GetCount);
        return await response.ToResultAsync<int>();
    }
    
    public async Task<IResult<PaginatedData<ReviewResponse>>> GetPaginatedReviewsAsync(
        int pageNumber, int pageSize)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(ReviewRoutes.GetPaginatedReviewsAsync(pageNumber, pageSize));
        return await response.ToResultAsync<PaginatedData<ReviewResponse>>();
    }

    public async Task<IResult> CreateAsync(CreateReviewRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(ReviewRoutes.Create, request);
        return await response.ToResultAsync();
    }
}