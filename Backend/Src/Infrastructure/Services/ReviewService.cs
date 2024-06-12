using Infrastructure.Extensions;

namespace Infrastructure.Services;

public class ReviewService(
    IHttpContextAccessor _httpContextAccessor,
    IReviewRepository reviewRepository)
    : IReviewService
{
    public async Task<Result<int>> GetCountAsync()
    {
        var reviewsCount = await reviewRepository.GetCountAsync();
        return Result<int>.Success(reviewsCount, "Кол-во оценок успешно получено.");
    }

    public async Task<Result<PaginatedData<ReviewResponse>>> GetPaginatedReviewsAsync(
        int pageNumber, int pageSize)
    {
        var (reviewsEntities, totalCount) = await reviewRepository.GetPaginatedReviewsAsync(
            pageNumber, pageSize);
        var reviewsResponse = reviewsEntities.Select(reviewEntity => 
            new ReviewResponse(
                Id: reviewEntity.Id,
                UserPicturePath: reviewEntity.User.PicturePath,
                Username: reviewEntity.User.Username,
                Content: reviewEntity.Content,
                Grade: reviewEntity.Grade)).ToList();
        return Result<PaginatedData<ReviewResponse>>
            .Success(new PaginatedData<ReviewResponse>(
                List: reviewsResponse, TotalCount: totalCount));
    }

    public async Task<Result> CreateAsync(CreateReviewRequest request)
    {
        var claims = _httpContextAccessor.HttpContext!.User;
        var currentUserId = Guid.Parse(claims.GetLoggedInUserId<string>());
        var reviewEntity = new ReviewEntity {
            UserId = currentUserId,
            Content = request.Content,
            Grade = request.Grade
        };
        await reviewRepository.CreateAsync(reviewEntity);
        return Result<string>.Success("Оценка успешно оставлена.");
    }
}