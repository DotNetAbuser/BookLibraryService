namespace Application.IRepositories;

public interface IBookRepository
{
    Task<PaginatedData<BookEntity>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<BookEntity?> GetByIdWithIncludesAsync(Guid id);

    Task<BookEntity?> GetByIdAsync(Guid id);
    Task UpdateAsync(BookEntity entity);
}