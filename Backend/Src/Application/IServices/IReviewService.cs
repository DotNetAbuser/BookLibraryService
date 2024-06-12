namespace Application.IServices;

public interface IReviewService
{
    Task<Result<int>> GetCountAsync();

    Task<Result<PaginatedData<ReviewResponse>>> GetPaginatedReviewsAsync(
        int pageNumber, int pageSize);

    Task<Result> CreateAsync(CreateReviewRequest request);
}