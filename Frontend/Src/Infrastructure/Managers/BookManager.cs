namespace Infrastructure.Managers;

public interface IBookManager
{
    Task<IResult<PaginatedData<BookResponse>>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<IResult<BookResponse>> GetByIdAsync(Guid id);
}

public class BookManager(
    IHttpClientFactory factory)
    : IBookManager
{
    public async Task<IResult<PaginatedData<BookResponse>>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(BookRoutes.GetPaginatedBooks(
                pageNumber,pageSize, searchTerms));
        return await response.ToResultAsync<PaginatedData<BookResponse>>();
    }

    public async Task<IResult<BookResponse>> GetByIdAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(BookRoutes.GetById(id));
        return await response.ToResultAsync<BookResponse>();
    }
}