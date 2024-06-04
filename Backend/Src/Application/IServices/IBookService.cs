namespace Application.IServices;

public interface IBookService
{
    Task<Result<PaginatedData<BookResponse>>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms);
}