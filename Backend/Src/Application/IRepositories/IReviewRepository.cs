namespace Application.IRepositories;

public interface IReviewRepository
{
    Task<PaginatedData<ReviewEntity>> GetPaginatedReviewsAsync(
        int pageNumber, int pageSize);

    Task CreateAsync(ReviewEntity entity);
    Task<int> GetCountAsync();
}