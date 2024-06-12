namespace Infrastructure.Managers;

public interface IBookManager
{
    Task<IResult<int>> GetCountAsync();
    
    Task<IResult<PaginatedData<BookResponse>>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<IResult<BookResponse>> GetByIdAsync(Guid id);
    Task<IResult> CreateAsync(CreateBookRequest request);
    Task<IResult> UpdateAsync(Guid id, UpdateBookRequest request);
    Task<IResult> DeleteAsync(Guid id);
}

public class BookManager(
    IHttpClientFactory factory)
    : IBookManager
{
    public async Task<IResult<int>> GetCountAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(BookRoutes.GetCount);
        return await response.ToResultAsync<int>();
    }

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

    public async Task<IResult> CreateAsync(CreateBookRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(BookRoutes.Create, request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> UpdateAsync(Guid id, UpdateBookRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(BookRoutes.Update(id), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .DeleteAsync(BookRoutes.Delete(id));
        return await response.ToResultAsync();
    }
}