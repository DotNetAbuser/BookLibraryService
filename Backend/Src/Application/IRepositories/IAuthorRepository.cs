namespace Application.IRepositories;

public interface IAuthorRepository
{
    Task<PaginatedData<AuthorEntity>> GetPaginatedAuthorsAsync(
        int pageNumber, int pageSize);

    Task<IEnumerable<AuthorEntity>> GetAllAsync();
}