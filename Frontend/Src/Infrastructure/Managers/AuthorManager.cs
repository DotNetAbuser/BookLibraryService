namespace Infrastructure.Managers;

public interface IAuthorManager
{
    Task<IResult<PaginatedData<AuthorResponse>>> GetPaginatedAuthorsAsync(
        int pageNumber, int pageSize);
}

public class AuthorManager(
    IHttpClientFactory factory)
    : IAuthorManager
{
    public async Task<IResult<PaginatedData<AuthorResponse>>> GetPaginatedAuthorsAsync(
        int pageNumber, int pageSize)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(AuthorRoutes.GetPaginatedAuthors(pageNumber, pageSize));
        return await response.ToResultAsync<PaginatedData<AuthorResponse>>();
    }
}