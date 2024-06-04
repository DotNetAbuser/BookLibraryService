namespace Application.IServices;

public interface IAuthorService
{
    Task<Result<PaginatedData<AuthorResponse>>> GetPaginatedAuthorsAsync(
        int pageNumber, int pageSize);
}