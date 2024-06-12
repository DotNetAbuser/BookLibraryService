namespace Application.IServices;

public interface IBookService
{
    Task<Result<int>> GetCountAsync();
    
    Task<Result<PaginatedData<BookResponse>>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms);

    Task<Result<BookResponse>> GetByIdAsync(Guid id);
    Task<Result> CreateAsync(CreateBookRequest request);
    Task<Result> UpdateAsync(Guid id, UpdateBookRequest request);
    Task<Result> DeleteAsync(Guid id);
}