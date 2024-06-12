namespace Application.IRepositories;

public interface IBookRepository
{
    Task<PaginatedData<BookEntity>> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<BookEntity?> GetByIdWithIncludesAsync(Guid id);

    Task<BookEntity?> GetByIdAsync(Guid id);
    
    Task CreateAsync(BookEntity entity);
    Task UpdateAsync(BookEntity entity);
    Task DeleteAsync(BookEntity entity);

    
    Task<bool> IsExistByTitleAsync(string title);
    Task<bool> IsExistForUpdateByTitleAsync(Guid id, string title);
    Task<int> GetCountAsync();
}