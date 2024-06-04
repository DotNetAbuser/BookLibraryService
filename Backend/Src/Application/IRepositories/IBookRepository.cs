namespace Application.IRepositories;

public interface IBookRepository
{
    Task<PaginatedData<BookEntity>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms);
}